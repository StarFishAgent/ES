using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinControl
{
    public partial class RichBoxController : UserControl
    {
        public RichBoxController()
        {
            InitializeComponent();
        }
        public void SetRtfText(string Rtfstr)
        {
            richEditControl1.RtfText= Rtfstr;
        }
    }
}
