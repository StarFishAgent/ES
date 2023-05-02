using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace WinClient
{
    public partial class FrmRegister : XtraForm
    {
        /// <summary>
        /// 注册窗体
        /// </summary>
        public FrmRegister()
        {
            InitializeComponent();
            #region 常用代码
            AutoScaleMode = AutoScaleMode.None;//窗体自动缩放
            FormBorderStyle = FormBorderStyle.FixedSingle;//设置边框样式
            MaximizeBox = false;//禁止最大化
            StartPosition = FormStartPosition.CenterScreen;//窗体居中
            #endregion
            cmbSex.SelectedIndex = 0;
            txtCardNo.SetWatermark("测试期间请输入卡号");
            txtUserNo.SetWatermark("请输入用户名");
            txtUserPwd.SetWatermark("请输入密码");
            txtUserRePwd.SetWatermark("请确认密码");
            txtUserName.SetWatermark("请输入用户姓名");
            //cmbSex.SetWatermark("请选择您的性别");
        }
        public FrmRegister(string card_no) : this()
        {
            this.txtCardNo.Text = card_no;
        }

        private void btnTakePhotos_Click(object sender, EventArgs e)
        {
            this.picb.ShowTakePictureDialog();
        }

        private void picb_DoubleClick(object sender, EventArgs e)
        {
            this.picb.ShowTakePictureDialog();
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.txtCardNo.ReadOnly = true;
            var user_no = this.txtUserNo.Text.Trim();
            var card_no = this.txtCardNo.Text.Trim();
            var user_pwd = this.txtUserPwd.Text.Trim();
            var user_repwd = this.txtUserRePwd.Text.Trim();
            var user_name = this.txtUserName.Text.Trim();
            var sex = this.cmbSex.Text.Trim() == "女" ? "1" : "0";
            var photo = picb.Image;
            if (string.IsNullOrEmpty(user_no))
            {
                MessageBox.Show("请输入用户名");
                return;
            }
            if (string.IsNullOrEmpty(user_pwd))
            {
                MessageBox.Show("请输入密码");
                return;
            }
            if (user_repwd != user_pwd)
            {
                MessageBox.Show("两次密码输入不一致");
                return;
            }
            if (string.IsNullOrEmpty(user_name))
            {
                MessageBox.Show("请输入姓名");
                return;
            }
            if (user_no.Length>15)
            {
                MessageBox.Show("用户名最多只能输入15个字符");
                return;
            }
            if (user_pwd.Length>20)
            {
                MessageBox.Show("密码最多只能输入20个字符");
                return;
            }
            if (user_name.Length>15)
            {
                MessageBox.Show("用户姓名最多只能输入15个字符");
                return;
            }
            if (card_no != "")
            {
                var dt = $@"select * from UserInfo where card_no=@card_no".ExecuteQuery(("@card_no", card_no));
                if (dt != null && dt.Rows.Count > 0)
                {
                    MessageBox.Show("卡号已存在");
                    return;
                }
            }
            {
                var dt = $@"select * from UserInfo where user_no=@user_no".ExecuteQuery(("@user_no", user_no));
                if (dt != null && dt.Rows.Count > 0)
                {
                    MessageBox.Show("用户名已存在");
                    return;
                }
            }
            if(user_no=="Admin" || user_no=="admin" || user_no == "--'1=1'--")
            {
                MessageBox.Show("不能注册该用户名请重新输入");
                return;
            }
            byte[] PhotoBytes = null;
            if (photo != null)
            {
                using (var ms = new MemoryStream())
                {
                    photo.Save(ms, ImageFormat.Bmp);
                    PhotoBytes = ms.ToArray();
                }
            }
            $@"insert into UserInfo(user_no,user_pwd,user_name,sex,photo,card_no,user_type,user_yn)values(@user_no,@user_pwd,@user_name,@sex,@photo,@card_no,0,0)".ExecuteNonQuery(("@user_no", user_no, typeof(string).FullName), (@"user_pwd", user_pwd, typeof(string).FullName), ("@user_name", user_name, typeof(string).FullName), (@"sex", sex, typeof(string).FullName), ("@photo", PhotoBytes, typeof(byte[]).FullName),("@card_no",card_no,typeof(string).FullName));
            MessageBox.Show("注册成功");
            this.Close();

        }

        private void timerCard_Tick(object sender, EventArgs e)
        {
            //var card_no = CardReader.Read();
            //if (card_no != "")
            //{
            //    this.txtCardNo.Text = card_no;
            //}
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            //timerCard.Start();
        }

        private void FrmRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            //timerCard.Stop();
        }
    }
}
