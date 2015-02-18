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

using System;
using System.ServiceModel;
using System.Runtime.InteropServices;

namespace FSXAssistantServer
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    struct APState
    {
        double Master;
        double AutoThrottle;
        double SpeedHold;
        double Airspeed;
        double DesiredVerticalSpeed;
        double VerticalSpeed;
        double HeadingHold;
        double Heading;
        double AltitudeHold;
        double Altitude;
        double BankAngle;
    }

    [ServiceContract]
    interface IFSXAssistant
    {
        [OperationContract]
        bool SimConnect_Start();

        [OperationContract]
        double SimConnect_Dispatch();

        [OperationContract]
        bool SimConnect_IsClosing();

        [OperationContract]
        APState AP_state();

        /// <summary>
        /// Returns the current state of the AP Master switch 
        /// </summary>
        [OperationContract]
        bool AP_master();

        /// <summary>
        /// Toggles the AP Master switch
        /// </summary>
        [OperationContract]
        void AP_toggleMaster();

        /// <summary>
        /// Returns the current state of the AP Auto Throttle switch
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool AP_autoThrottle();

        /// <summary>
        /// Toggles the AP Auto Throttle switch
        /// </summary>
        [OperationContract]
        void AP_toggleAutoThrottle();

        /// <summary>
        /// Returns the current AP desired Heading
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        double AP_heading();

        /// <summary>
        /// Sets the AP Heading
        /// </summary>
        /// <param name="heading"></param>
        [OperationContract]
        void AP_setHeading(double heading);

        /// <summary>
        /// Returns the TRUE vertical speed. Not to be confused with "Desired Vertical Speed"
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        double AP_verticalAirspeed();

        /// <summary>
        /// Returns the current desired Vertical Speed
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        double AP_desiredVerticalAirspeed();

        /// <summary>
        /// Sets the desired Vertical Speed
        /// </summary>
        [OperationContract]
        void AP_setDesiredVerticalAirspeed(double airspeed);

        /// <summary>
        /// Returns the current AP desired Airspeed
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        double AP_airspeed();

        /// <summary>
        /// Sets the current AP desired Airspeed
        /// </summary>
        [OperationContract]
        void AP_setAirspeed(double airspeed);

        /// <summary>
        /// Returns the current state of the AP Speed Hold
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool AP_airspeedHold();

        /// <summary>
        /// Toggles the AP Speed switch
        /// </summary>
        [OperationContract]
        void AP_toggleSpeedHold();

        /// <summary>
        /// Returns the current state of the AP Heading switch
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool AP_headingHold();

        /// <summary>
        /// Toggles the AP Heading switch
        /// </summary>
        [OperationContract]
        void AP_toggleHeadingHold();

        /// <summary>
        /// Returns the current state of the AP Heading switch
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool AP_altitudeHold();

        /// <summary>
        /// Toggles the AP Heading switch
        /// </summary>
        [OperationContract]
        void AP_toggleAltitudeHold();

        /// <summary>
        /// Returns the current desired Altitude
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        double AP_altitude();

        /// <summary>
        /// Sets the desired Altitude
        /// </summary>
        /// <param name="altitude"></param>
        [OperationContract]
        void AP_setAltitude(double altitude);

        /// <summary>
        /// Returns the current Max. Bank Angle
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        double AP_maxBankAngle();

        /// <summary>
        /// Increases the Max. Bank Angle
        /// </summary>
        [OperationContract]
        void AP_increaseMaxBankAngle();

        /// <summary>
        /// Decreases the Max. Bank Angle
        /// </summary>
        [OperationContract]
        void AP_decreaseMaxBankAngle();
    }
}
