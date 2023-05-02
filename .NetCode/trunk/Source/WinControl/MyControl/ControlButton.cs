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
    public partial class StarButton : UserControl
    {
        public StarButton()
        {
            InitializeComponent();
        }
        public void SetBtnText(string Text)
        {
            btnView.Text = Text;
        }
    }
}
