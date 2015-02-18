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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSXAssistantWinDesktopClient
{
    public partial class FrmMain : Form
    {
        private FSXAssistantServiceReference.FSXAssistantClient serviceClient;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void UpdateGUI()
        {
            chkAPMaster.Checked = serviceClient.AP_master();
            chkAT.Checked = serviceClient.AP_autoThrottle();
            chkHdgSel.Checked = serviceClient.AP_headingHold();
            chkSpeed.Checked = serviceClient.AP_airspeedHold();
            chkAltHold.Checked = serviceClient.AP_altitudeHold();

            txtVertSpeed.Text = Math.Round(serviceClient.AP_verticalAirspeed(), 2).ToString();
            txtMaxBankAngle.Text = Convert.ToInt32(serviceClient.AP_maxBankAngle()).ToString();
            

            if (!csAltitude.IsBeingModified)
            {
                csAltitude.SkipValueChangedEvent = true;
                csAltitude.Value = Convert.ToInt32(serviceClient.AP_altitude());
            }

            if (!csSpeed.IsBeingModified)
            {
                csSpeed.SkipValueChangedEvent = true;
                csSpeed.Value = Convert.ToInt32(serviceClient.AP_airspeed());
            }

            if (!csHeading.IsBeingModified)
            {
                csHeading.SkipValueChangedEvent = true;
                csHeading.Value = Convert.ToInt32(serviceClient.AP_heading());
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            serviceClient = new FSXAssistantServiceReference.FSXAssistantClient();
            try
            {
                serviceClient.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect with FSXAssistantServer:" + Environment.NewLine + ex.Message);
                this.Close();
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(serviceClient.SimConnect_IsClosing())
            {
                this.Close();
            }

            serviceClient.SimConnect_Dispatch();
            UpdateGUI();
        }

        private void chkAPMaster_Click(object sender, EventArgs e)
        {
            serviceClient.AP_toggleMaster();
        }

        private void chkAT_Click(object sender, EventArgs e)
        {
            serviceClient.AP_toggleAutoThrottle();
        }

        private void chkHdgSel_Click(object sender, EventArgs e)
        {
            serviceClient.AP_toggleHeadingHold();
        }

        private void chkSpeed_Click(object sender, EventArgs e)
        {
            // for some reason when toggling the Speed Hold the desired airspeed is set to zero, so...
            int currentValue = csSpeed.Value; // backup the current value
            serviceClient.AP_toggleSpeedHold();
            csSpeed.Value = currentValue; // restore the desired airspeed value
        }

        private void chkAltHold_Click(object sender, EventArgs e)
        {
            serviceClient.AP_toggleAltitudeHold();
        }

        private void csHeading_ValueChanged(object sender, EventArgs e)
        {
            var customSelector = sender as CustomSelector;
            serviceClient.AP_setHeading(Convert.ToDouble(customSelector.Value));
        }

        private void csSpeed_ValueChanged(object sender, EventArgs e)
        {
            var customSelector = sender as CustomSelector;
            serviceClient.AP_setAirspeed(Convert.ToDouble(customSelector.Value));
        }

        private void csAltitude_ValueChanged(object sender, EventArgs e)
        {
            var customSelector = sender as CustomSelector;
            serviceClient.AP_setAltitude(Convert.ToDouble(customSelector.Value));
        }

        private void csVertSpeed_ValueChanged(object sender, EventArgs e)
        {
            var customSelector = sender as CustomSelector;
            serviceClient.AP_setDesiredVerticalAirspeed(Convert.ToDouble(customSelector.Value));
        }

        private void btnDecreaseBankAngle_Click(object sender, EventArgs e)
        {
            serviceClient.AP_decreaseMaxBankAngle();
        }

        private void btnIncreaseBankAngle_Click(object sender, EventArgs e)
        {
            serviceClient.AP_increaseMaxBankAngle();            
        }
    }
}
