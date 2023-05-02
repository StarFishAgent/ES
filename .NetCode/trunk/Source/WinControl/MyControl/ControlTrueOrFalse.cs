using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControl.MyControl;

namespace WinControl
{
    public partial class ISTrueOrFalse : UserControl
    {
        public ISTrueOrFalse()
        {
            InitializeComponent();
        }
       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PanelControlAll panelControl = new PanelControlAll();

            panelControl.GetIsRadioButtonText(Helper.GetPanel, Helper.GetControlAnswer);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PanelControlAll panelControl = new PanelControlAll();

            panelControl.GetIsRadioButtonText(Helper.GetPanel, Helper.GetControlAnswer);
        }
    }
}
