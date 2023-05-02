using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace WinControl.MyControl
{
    public partial class RichBoxSingle : UserControl
    {
        public RichBoxSingle()
        {
            InitializeComponent();
            radioButton1.AutoCheck = false;
        }
        /// <summary>
        /// radiobutton点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_Click(object sender, EventArgs e)
        {
            PanelControlAll panelControl = new PanelControlAll();
            if (Helper.GetControlAnswer != null) {

                if (radioButton1.Checked == true) {
                    radioButton1.Checked = false;
                    panelControl.SetNullTextAnswer(Helper.GetControlAnswer);
                }
                else {
                    panelControl.SetRadioButtonChecked(Helper.GetPanel);
                    radioButton1.Checked = true;
                    panelControl.SetAnswerText(radioButton1.Text, Helper.GetControlAnswer);
                }
                return;
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
