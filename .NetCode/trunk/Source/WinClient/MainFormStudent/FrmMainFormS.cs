using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControl.MyControl;
using WinClient.Helper;
using WinClient.UserPage;

namespace WinClient
{
    public partial class FrmMainFormS : XtraForm
    {
        public FrmMainFormS()
        {
            InitializeComponent();
        }

        private void FrmMainFormS_Load(object sender, EventArgs e)
        {
            btnUser.Caption = "欢迎回来  " + Program.user_no;
            var dt =  "select exam_type from ExamTypeInfo".ExecuteQuery();
            
            for (int times = 0; times < dt.Rows.Count; times++)
            {
                StarButton starButton = new StarButton();
                starButton.SetBtnText(Convert.ToString(dt.Rows[times]["exam_type"]));
                flowLayoutPanel1.Controls.Add(starButton);
                starButton.btnView.Click += new EventHandler(StarButton_ItemClick);
            }
        }
        private void StarButton_ItemClick(object sender, EventArgs e)
        {
            var frm = new FrmAnswerQ((sender as SimpleButton).Text.ToString());
            frm.ShowDialog();
             
        }
        private void btnUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmUserInfo();
            frm.ShowDialog();
            frm.Close();
        }

        private void btnChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var json = AppDomain.CurrentDomain.BaseDirectory + "user.json";
            var dic = File.ReadAllText(json).ToDynamic();
            dic.is_auto = false;
            File.WriteAllText(json, JsonConvert.SerializeObject(dic));
            this.Hide();
            var frm = new FrmLogin();
            frm.ShowDialog();
        }
    }
}
