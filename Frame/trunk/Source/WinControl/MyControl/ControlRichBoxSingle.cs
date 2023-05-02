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


namespace WinControl.MyControl
{
    public partial class RichBoxSingle : UserControl
    {
        public RichBoxSingle()
        {
            InitializeComponent();
            radioButton1.AutoCheck = false;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            PanelControlAll panelControl = new PanelControlAll();
            
            if (radioButton1.Checked == true)
            {
                
                radioButton1.Checked = false;
                panelControl.SetNullTextAnswer(Helper.GetControlAnswer);
            }
            else
            {
                var panel = Helper.GetPanel;
                panelControl.SetRadioButtonChecked(panel);
                radioButton1.Checked = true;
                panelControl.SetTextAnswer(radioButton1.Text,Helper.GetControlAnswer);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
