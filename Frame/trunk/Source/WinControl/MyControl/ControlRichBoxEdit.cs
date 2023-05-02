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
    public partial class RichBoxEdit : UserControl
    {
        public RichBoxEdit()
        {
            InitializeComponent();
        }
        public object GetText()
        {
            var Result = "";
            Result=richEditControl1.Text;
            return Result;
        }
        public object GetRtfText()
        {
            var Result = "";
            Result=richEditControl1.RtfText;
            return Result;
        }
        public void SetText(object obj)
        {
            richEditControl1.Text = obj.ToString();
        }
        public void SetnullText()
        {
            richEditControl1.Text = "";
            richEditControl1.Text = null;
        }
        public void SetRtfText(object obj)
        {
            richEditControl1.RtfText = obj.ToString();
        }


    }
}
