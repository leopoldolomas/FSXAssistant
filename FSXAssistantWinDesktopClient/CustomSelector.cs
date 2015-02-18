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
using System.Windows.Forms;

namespace FSXAssistantWinDesktopClient
{
    public partial class CustomSelector : UserControl
    {
        #region Events
        public event EventHandler ValueChanged;
        #endregion

        #region Properties
        private int m_value;
        public int Value {
            get { return ClampedValue(m_value); }
            set 
            { 
                m_value = ClampedValue(value);
                UpdateValueFromTextInput();

                if(!SkipValueChangedEvent && ValueChanged != null)
                {
                    ValueChanged(this, EventArgs.Empty);
                }
                SkipValueChangedEvent = false;
            }
        }

        public bool IsBeingModified { get; set; }
        public bool SkipValueChangedEvent { get; set; }
        public bool ClampValue { get; set; }
        public int MinimumValue { get; set; }
        public int MaximumValue { get; set; }
        public int Rate { get; set; }
        public int QuickRate { get; set; }
        #endregion

        #region Constructor(s)
        public CustomSelector()
        {
            InitializeComponent();

            Rate =  1;
            QuickRate = 10;
            MinimumValue = 0;
            MaximumValue = Int32.MaxValue;
            Value = 0;
            SkipValueChangedEvent = false;
            IsBeingModified = false;
        }
        #endregion

        #region Methods
        private void UpdateValueFromTextInput()
        {
            txtValue.Text = Value.ToString();
        }

        private int ClampedValue(int v)
        {
            if (ClampValue)
            {
                return (v < MinimumValue) ? MinimumValue : (v > MaximumValue) ? MaximumValue : v;
            }
            else
            {
                if (v < MinimumValue)
                {
                    v = MaximumValue;
                }
                else if (v > MaximumValue)
                {
                    v = MinimumValue;
                }
            }
            return v;
        }

        private void SubmitNewValue()
        {
            int newValue = 0;
            bool successful = Int32.TryParse(txtValue.Text.Trim(), out newValue);
            newValue = successful ? newValue : MinimumValue;
            Value = newValue;
            IsBeingModified = false;
        }
        #endregion

        #region Events

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            Value += Rate;
        }

        private void btnQuickIncrease_Click(object sender, EventArgs e)
        {
            Value += QuickRate;
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            Value -= Rate;
        }

        private void btnQuickDecrease_Click(object sender, EventArgs e)
        {
            Value -= QuickRate;
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SubmitNewValue();
            }
        }

        private void txtValue_Leave(object sender, EventArgs e)
        {
            SubmitNewValue();
        }

        private void txtValue_Enter(object sender, EventArgs e)
        {
            IsBeingModified = true;
        }
        #endregion
    }
}
