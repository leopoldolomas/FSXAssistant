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
using System.Runtime.InteropServices;

namespace FSXAssistantServer
{
    class FSXAssistantService : IFSXAssistant
    {
        #region DLLImports
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern bool FSXAssistant_SimConnect_Start();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern double FSXAssistant_SimConnect_Dispatch();

        [DllImport(@"FSXAssistantDLL.dll")]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool FSXAssistant_SimConnect_IsClosing();

        [DllImport(@"FSXAssistantDLL.dll", CallingConvention=CallingConvention.Cdecl)]
        private static extern APState FSXAssistant_AP_State();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern double FSXAssistant_AP_Master();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern void FSXAssistant_AP_ToggleMaster();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern double FSXAssistant_AP_AutoThrottle();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern void FSXAssistant_AP_ToggleAutoThrottle();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern double FSXAssistant_AP_Heading();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern void FSXAssistant_AP_SetHeading(double heading);

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern double FSXAssistant_AP_VerticalAirspeed();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern double FSXAssistant_AP_DesiredVerticalSpeed();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern void FSXAssistant_AP_SetDesiredVerticalSpeed(double vertical_speed);

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern void FSXAssistant_AP_SetAirspeed(double speed);

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern double FSXAssistant_AP_Airspeed();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern double FSXAssistant_AP_ToggleSpeedHold();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern double FSXAssistant_AP_ToggleHeadingHold();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern double FSXAssistant_AP_ToggleAltitudeHold();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern double FSXAssistant_AP_AirspeedHold();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern double FSXAssistant_AP_AltitudeHold();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern double FSXAssistant_AP_HeadingHold();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern double FSXAssistant_AP_Altitude();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern void FSXAssistant_AP_SetAltitude(double altitude);

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern double FSXAssistant_AP_MaxBankAngle();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern void FSXAssistant_AP_IncreaseMaxBankAngle();

        [DllImport(@"FSXAssistantDLL.dll")]
        private static extern void FSXAssistant_AP_DecreaseMaxBankAngle();
        #endregion

        #region Service Methods
        public bool SimConnect_Start()
        {
            return FSXAssistant_SimConnect_Start();
        }

        public double SimConnect_Dispatch()
        {
            return FSXAssistant_SimConnect_Dispatch();
        }
        
        public bool SimConnect_IsClosing()
        {
            return FSXAssistant_SimConnect_IsClosing();
        }

        public APState AP_state()
        {
            return FSXAssistant_AP_State();
        }

        public bool AP_master()
        {
            return Convert.ToBoolean(FSXAssistant_AP_Master());
        }

        public void AP_toggleMaster()
        {
            FSXAssistant_AP_ToggleMaster();
        }

        public bool AP_autoThrottle()
        {
            return Convert.ToBoolean(FSXAssistant_AP_AutoThrottle());
        }

        public void AP_toggleAutoThrottle()
        {
            FSXAssistant_AP_ToggleAutoThrottle();
        }

        public double AP_heading()
        {
            return FSXAssistant_AP_Heading();
        }

        public void AP_setHeading(double heading)
        {
            FSXAssistant_AP_SetHeading(heading);
        }

        public double AP_verticalAirspeed()
        {
            return FSXAssistant_AP_VerticalAirspeed();
        }

        public double AP_desiredVerticalAirspeed()
        {
            return FSXAssistant_AP_DesiredVerticalSpeed();
        }

        public void AP_setDesiredVerticalAirspeed(double airspeed)
        {
            FSXAssistant_AP_SetDesiredVerticalSpeed(airspeed);
        }

        public double AP_airspeed()
        {
            return FSXAssistant_AP_Airspeed();
        }

        public void AP_setAirspeed(double airspeed)
        {
            FSXAssistant_AP_SetAirspeed(airspeed);
        }

        public bool AP_airspeedHold()
        {
            return Convert.ToBoolean(FSXAssistant_AP_AirspeedHold());
        }

        public void AP_toggleSpeedHold()
        {
            FSXAssistant_AP_ToggleSpeedHold();
        }

        public bool AP_headingHold()
        {
            return Convert.ToBoolean(FSXAssistant_AP_HeadingHold());
        }

        public void AP_toggleHeadingHold()
        {
            FSXAssistant_AP_ToggleHeadingHold();
        }

        public bool AP_altitudeHold()
        {
            return Convert.ToBoolean(FSXAssistant_AP_AltitudeHold());
        }

        public void AP_toggleAltitudeHold()
        {
            FSXAssistant_AP_ToggleAltitudeHold();
        }

        public double AP_altitude()
        {
            return FSXAssistant_AP_Altitude();
        }

        public void AP_setAltitude(double altitude)
        {
            FSXAssistant_AP_SetAltitude(altitude);
        }

        public double AP_maxBankAngle()
        {
            return FSXAssistant_AP_MaxBankAngle();
        }

        public void AP_increaseMaxBankAngle()
        {
            FSXAssistant_AP_IncreaseMaxBankAngle();
        }

        public void AP_decreaseMaxBankAngle()
        {
            FSXAssistant_AP_DecreaseMaxBankAngle();
        }
        #endregion
    }
}
