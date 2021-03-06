//--------------------------------------------------------------- @License begins
// "FSXAssistant"
// 2015 Leopoldo Lomas Flores. Torreon, Coahuila. MEXICO
// leopoldolomas [at] gmail
// www.leopoldolomas.info
// 
// This is free and unencumbered software released into the public domain.
// 
// Anyone is free to copy, modify, publish, use, compile, sell, or distribute this
// software, either in source code form or as a compiled binary, for any purpose,
// commercial or non-commercial, and by any means.
// 
// In jurisdictions that recognize copyright laws, the author or authors of this
// software dedicate any and all copyright interest in the software to the public
// domain. We make this dedication for the benefit of the public at large and to
// the detriment of our heirs and successors. We intend this dedication to be
// an overt act of relinquishment in perpetuity of all present and future
// rights to this software under copyright law.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//--------------------------------------------------------------- @License ends

// определяет точку входа для консольного приложения.

#include <tchar.h>
#include <stdio.h>
#include <strsafe.h>
#include "stdafx.h"
#include "SimConnect.h"

//----------------------------------------------------------------------------- Data Structs

struct APState {
	double Master				= 0.0; // whether the AP Master switch is active
	double AutoThrottle			= 0.0; // whether the AP Autothrottle is active
	double SpeedHold			= 0.0; // whether the AP Speed switch is active
	double Airspeed				= 0.0; // AP desired airspeed in knots	
	double DesiredVerticalSpeed = 0.0; // AP desired vertical speed in feets/minute
	double VerticalSpeed		= 0.0; // TRUE vertical airspeed in feets/second
	double HeadingHold			= 0.0; // whether the AP Heading switch is active
	double Heading				= 0.0; // AP desired heading
	double AltitudeHold			= 0.0; // whether the AP Altitude switch is active
	double Altitude				= 0.0; // AP desired altitude
	double BankAngle			= 0.0; // AP Max Bank Angle
};

static enum INPUT_ID {
	INPUT0,
};

static enum GROUP_ID {
	GROUP0,
};

static enum EVENT_ID {
	EVENT_SIM_START,
	EVENT_AP_MASTER,
	EVENT_AP_AUTO_THROTTLE_ARM,
	EVENT_AP_SET_HEADING,
	EVENT_AP_SET_AIRSPEED,
	EVENT_AP_SET_VERTICAL_SPEED,
	EVENT_AP_SET_ALTITUDE,
	EVENT_AP_INC_MAX_BANK_ANGLE,
	EVENT_AP_DEC_MAX_BANK_ANGLE,
	EVENT_AP_TOGGLE_AIRSPEED_HOLD,
	EVENT_AP_TOGGLE_HEADING_HOLD,
	EVENT_AP_TOGGLE_ALTITUDE_HOLD
};

static enum DATA_DEFINE_ID {
	DEFINITION_PDR,
};

static enum DATA_REQUEST_ID {
	REQUEST_PDR,
};

//----------------------------------------------------------------------------- Static vars

int     quit = 0;
HANDLE  hSimConnect = NULL;
APState* autoPilotState = new APState;


//----------------------------------------------------------------------------- SimConnect methods

void CALLBACK MyDispatchProcDLL(SIMCONNECT_RECV* pData, DWORD cbData, void *pContext)
{
	HRESULT hr;

	switch (pData->dwID)
	{
	case SIMCONNECT_RECV_ID_EVENT:
	{
		SIMCONNECT_RECV_EVENT *evt = (SIMCONNECT_RECV_EVENT*)pData;

		switch (evt->uEventID)
		{
		// TODO
		default:
			break;
		}
		break;
	}
	case SIMCONNECT_RECV_ID_SIMOBJECT_DATA_BYTYPE:
	{
		SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE *pObjData = (SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE*)pData;

		switch (pObjData->dwRequestID)
		{
		case REQUEST_PDR:
		{
			DWORD ObjectID = pObjData->dwObjectID;
			autoPilotState = (APState*)&pObjData->dwData;			
			break;
		}
		default:
			break;
		}
		break;
	}
	case SIMCONNECT_RECV_ID_QUIT:
	{
		quit = 1;
		break;
	}
	default:
		break;
	}
}

HRESULT mapClientEventToSimEvent(EVENT_ID event_id, GROUP_ID group_id, const char* sim_event) {
	HRESULT hr;
	hr = SimConnect_MapClientEventToSimEvent(hSimConnect, event_id, sim_event);
	hr = SimConnect_AddClientEventToNotificationGroup(hSimConnect, group_id, event_id);

	return hr;
}

int __stdcall DLLStart(void)
{
	HRESULT hr;

	printf("\nAttempting to connect with SimConnect server...");
	if (SUCCEEDED(SimConnect_Open(&hSimConnect, "DLL name", NULL, 0, NULL, 0)))
	{
		printf("\nConnection successful!\n");

		// EVENTS
		hr = mapClientEventToSimEvent(EVENT_AP_MASTER,				 GROUP0, "AP_MASTER"			  );
		hr = mapClientEventToSimEvent(EVENT_AP_AUTO_THROTTLE_ARM,    GROUP0, "AUTO_THROTTLE_ARM"	  );
		hr = mapClientEventToSimEvent(EVENT_AP_SET_HEADING,          GROUP0, "HEADING_BUG_SET"		  );
		hr = mapClientEventToSimEvent(EVENT_AP_SET_AIRSPEED,         GROUP0, "AP_SPD_VAR_SET"		  );
		hr = mapClientEventToSimEvent(EVENT_AP_TOGGLE_AIRSPEED_HOLD, GROUP0, "AP_AIRSPEED_HOLD"		  );
		hr = mapClientEventToSimEvent(EVENT_AP_TOGGLE_HEADING_HOLD,  GROUP0, "AP_PANEL_HEADING_HOLD"  );
		hr = mapClientEventToSimEvent(EVENT_AP_TOGGLE_ALTITUDE_HOLD, GROUP0, "AP_PANEL_ALTITUDE_HOLD" );
		hr = mapClientEventToSimEvent(EVENT_AP_SET_ALTITUDE,	     GROUP0, "AP_ALT_VAR_SET_ENGLISH" );
		hr = mapClientEventToSimEvent(EVENT_AP_SET_VERTICAL_SPEED,   GROUP0, "AP_VS_VAR_SET_ENGLISH"  );
		hr = mapClientEventToSimEvent(EVENT_AP_INC_MAX_BANK_ANGLE,   GROUP0, "AP_MAX_BANK_INC"		  );
		hr = mapClientEventToSimEvent(EVENT_AP_DEC_MAX_BANK_ANGLE,   GROUP0, "AP_MAX_BANK_DEC"        );

		// DATA
		hr = SimConnect_AddToDataDefinition(hSimConnect, DEFINITION_PDR, "AUTOPILOT MASTER",			"Bool"			  );
		hr = SimConnect_AddToDataDefinition(hSimConnect, DEFINITION_PDR, "AUTOPILOT THROTTLE ARM",		"Bool"			  );
		hr = SimConnect_AddToDataDefinition(hSimConnect, DEFINITION_PDR, "AUTOPILOT AIRSPEED HOLD",		"Bool"			  );
		hr = SimConnect_AddToDataDefinition(hSimConnect, DEFINITION_PDR, "AUTOPILOT AIRSPEED HOLD VAR", "Knots"			  );
		hr = SimConnect_AddToDataDefinition(hSimConnect, DEFINITION_PDR, "AUTOPILOT VERTICAL HOLD VAR", "Feet/Minute"	  );
		hr = SimConnect_AddToDataDefinition(hSimConnect, DEFINITION_PDR, "VERTICAL SPEED",				"Feet per second" );
		hr = SimConnect_AddToDataDefinition(hSimConnect, DEFINITION_PDR, "AUTOPILOT HEADING LOCK",		"Bool"			  );
		hr = SimConnect_AddToDataDefinition(hSimConnect, DEFINITION_PDR, "AUTOPILOT HEADING LOCK DIR",	"Degrees"		  );
		hr = SimConnect_AddToDataDefinition(hSimConnect, DEFINITION_PDR, "AUTOPILOT ALTITUDE LOCK",	    "Bool"			  );
		hr = SimConnect_AddToDataDefinition(hSimConnect, DEFINITION_PDR, "AUTOPILOT ALTITUDE LOCK VAR", "Feet"			  );
		hr = SimConnect_AddToDataDefinition(hSimConnect, DEFINITION_PDR, "AUTOPILOT MAX BANK",			 "Degrees"		  );

		hr = SimConnect_AddClientEventToNotificationGroup(hSimConnect, GROUP0, EVENT_SIM_START);
		hr = SimConnect_SetNotificationGroupPriority(hSimConnect, GROUP0, SIMCONNECT_GROUP_PRIORITY_HIGHEST);
		hr = SimConnect_SetInputGroupState(hSimConnect, INPUT0, SIMCONNECT_STATE_ON);
		hr = SimConnect_SubscribeToSystemEvent(hSimConnect, EVENT_SIM_START, "SimStart");

		return 1;
	}
	else {
		printf("\nCould not connect with SimConnect server!\n");
	}
	return 0;
}

void __stdcall DLLStop(void)
{
	// Close the client
	if (hSimConnect != NULL) {
		HRESULT hr = SimConnect_Close(hSimConnect);
	}
}

//----------------------------------------------------------------------------- FSXAssistant methods

/// Attempts to connect with the SimConnect server. Call this just once.
bool FSXAssistant_SimConnect_Start() {
	return DLLStart() == 1;
}

/// Dispatches SimmConnect events.
void FSXAssistant_SimConnect_Dispatch() {
	SimConnect_CallDispatch(hSimConnect, MyDispatchProcDLL, NULL);
	SimConnect_RequestDataOnSimObjectType(hSimConnect, REQUEST_PDR, DEFINITION_PDR, 0, SIMCONNECT_SIMOBJECT_TYPE_USER);
}

/// True only if the SimConnect server is being closed.
bool FSXAssistant_SimConnect_IsClosing() {
	return quit;
}

APState FSXAssistant_AP_State() {
	return (*autoPilotState);
}

/// Returns the current state of the AP Master switch
double FSXAssistant_AP_Master() {	
	return autoPilotState->Master;
}

/// Toggles the AP Master switch.
void FSXAssistant_AP_ToggleMaster() {
	SimConnect_TransmitClientEvent(hSimConnect, 0, EVENT_AP_MASTER, 0, GROUP0, 0);
}

/// Returns the corrent state of the AP Auto Throttle switch
double FSXAssistant_AP_AutoThrottle() {
	return autoPilotState->AutoThrottle;
}

/// Toggles the AP Auto Throttle switch.
void FSXAssistant_AP_ToggleAutoThrottle() {
	SimConnect_TransmitClientEvent(hSimConnect, 0, EVENT_AP_AUTO_THROTTLE_ARM, 0, GROUP0, 0);
}

/// Returns the current AP desired Heading.
double FSXAssistant_AP_Heading() {
	return autoPilotState->Heading;	
}

/// Sets the AP Heading.
void FSXAssistant_AP_SetHeading(double heading) {
	SimConnect_TransmitClientEvent(hSimConnect, 0, EVENT_AP_SET_HEADING, heading, GROUP0, 0);
}

/// Returns the TRUE vertical speed. Not to be confused with "Desired Vertical Speed"
double FSXAssistant_AP_VerticalAirspeed() {
	return autoPilotState->VerticalSpeed;
}

/// Returns the current desired Vertical Speed.
double FSXAssistant_AP_DesiredVerticalSpeed() {
	return autoPilotState->DesiredVerticalSpeed;
}

/// Sets de desired Vertical Speed
void FSXAssistant_AP_SetDesiredVerticalSpeed(double vertical_speed) {
	SimConnect_TransmitClientEvent(hSimConnect, 0, EVENT_AP_SET_VERTICAL_SPEED, vertical_speed, GROUP0, 0);
}

/// Returns the current AP desired Airspeed.
double FSXAssistant_AP_Airspeed() {
	return autoPilotState->Airspeed;
}

/// Sets the AP desired AirSpeed.
void FSXAssistant_AP_SetAirspeed(double speed) {
	SimConnect_TransmitClientEvent(hSimConnect, 0, EVENT_AP_SET_AIRSPEED, speed, GROUP0, 0);
}

/// Returns the current state of the AP Speed switch.
double FSXAssistant_AP_AirspeedHold() {
	return autoPilotState->SpeedHold;
}

/// Toggles the AP Speed switch.
void FSXAssistant_AP_ToggleSpeedHold() {
	SimConnect_TransmitClientEvent(hSimConnect, 0, EVENT_AP_TOGGLE_AIRSPEED_HOLD, 0, GROUP0, 0);
}

/// Returns the current state of the AP Heading switch.
double FSXAssistant_AP_HeadingHold() {
	return autoPilotState->HeadingHold;
}

/// Toggles the AP Heading switch.
void FSXAssistant_AP_ToggleHeadingHold() {
	SimConnect_TransmitClientEvent(hSimConnect, 0, EVENT_AP_TOGGLE_HEADING_HOLD, 0, GROUP0, 0);
}

/// Returns the current state of the AP Heading switch.
double FSXAssistant_AP_AltitudeHold() {
	return autoPilotState->AltitudeHold;
}

/// Toggles the AP Heading switch.
void FSXAssistant_AP_ToggleAltitudeHold() {
	SimConnect_TransmitClientEvent(hSimConnect, 0, EVENT_AP_TOGGLE_ALTITUDE_HOLD, 0, GROUP0, 0);
} 

/// Returns the current desired Altitude.
double FSXAssistant_AP_Altitude() {
	return autoPilotState->Altitude;
}

/// Sets the desired Altitude.
void FSXAssistant_AP_SetAltitude(double altitude) {
	SimConnect_TransmitClientEvent(hSimConnect, 0, EVENT_AP_SET_ALTITUDE, altitude, GROUP0, 0);
}

/// Returns the current Max. Bank Angle
double FSXAssistant_AP_MaxBankAngle() {
	return autoPilotState->BankAngle;
}

/// Increases the Max. Bank Angle
void FSXAssistant_AP_IncreaseMaxBankAngle() {
	SimConnect_TransmitClientEvent(hSimConnect, 0, EVENT_AP_INC_MAX_BANK_ANGLE, 0, GROUP0, 0);
}

/// Decreases the Max. Bank Angle
void FSXAssistant_AP_DecreaseMaxBankAngle() {
	SimConnect_TransmitClientEvent(hSimConnect, 0, EVENT_AP_DEC_MAX_BANK_ANGLE, 0, GROUP0, 0);
}