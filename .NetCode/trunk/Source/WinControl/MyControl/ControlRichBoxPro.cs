using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinControl.MyControl
{
    public partial class RichBoxPro : UserControl
    {
        public RichBoxPro()
        {
            InitializeComponent();
        }
        public void SetText()
        {

        }
        private void ChkABCD_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void ChkABCD_Click(object sender, EventArgs e)
        {
            PanelControlAll panelControl = new PanelControlAll();

            panelControl.GetCheckEditText(Helper.GetPanel, Helper.GetControlAnswer);
        }
    }
}
