using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Newtonsoft.Json;

using WinClient.Helper;
using WinClient.Properties;

namespace WinClient.UserPage
{
    public partial class FrmLogin : XtraForm
    {
        /// <summary>
        /// 登录窗体
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
            #region 常用代码
            AutoScaleMode = AutoScaleMode.None;//窗体自动缩放
            FormBorderStyle = FormBorderStyle.FixedSingle;//设置边框样式
            MaximizeBox = false;//禁止最大化
            StartPosition = FormStartPosition.CenterScreen;//窗体居中
            #endregion
            txtUserNo.SetWatermark("请输入用户名");
            txtUserPwd.SetWatermark("请输入密码");
            //#region 设置pictureBox图片控件为圆的
            //GraphicsPath gp = new GraphicsPath();
            //gp.AddEllipse(picbhead.ClientRectangle);
            //Region region = new Region(gp);
            //picbhead.Region = region;
            //gp.Dispose();
            //region.Dispose();
            //#endregion
        }


        private void timerLogin_Tick(object sender, EventArgs e)
        {
            var card_no = CardReader.Read();
            if (card_no != "")
            {
                var dt = $@"select * from UserInfo where card_no=@card_no".ExecuteQuery(("@card_no", card_no));
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.timerCard.Stop();
                    var dr = dt.Rows[0];
                    Program.user_guid = Convert.ToString(dr["guid"]);
                    this.Hide();
                    var frm = new FrmMainForm();
                    var dia = frm.ShowDialog();
                    if (dia == DialogResult.OK)
                    {
                        this.Show();
                        this.timerCard.Start();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.timerCard.Stop();
                    this.Hide();
                    var frm = new FrmRegister(card_no);
                    frm.ShowDialog();
                    this.Show();
                    this.timerCard.Start();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.timerCard.Stop();
            var user_no = this.txtUserNo.Text.Trim();
            var user_pwd = this.txtUserPwd.Text.Trim();
            var is_rem = this.chkRem.Checked;
            var is_auto = this.chkAuto.Checked;
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
            var dt = $@"select * from UserInfo where user_no=@user_no and user_pwd=@user_pwd".ExecuteQuery(("@user_no", user_no), ("@user_pwd", user_pwd));
            if (dt != null && dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
                Program.user_guid = Convert.ToString(dr["guid"]);
                Program.user_no = Convert.ToString(dr["user_no"]);
                var FilePath = AppDomain.CurrentDomain.BaseDirectory + "user.json";
                var json = JsonConvert.SerializeObject(new { user_no = user_no, user_pwd = (is_rem == true ? user_pwd : ""), is_auto = is_auto, is_rem = is_rem });
                File.WriteAllText(FilePath, json, Encoding.UTF8);
                this.Hide();
                if (Convert.ToInt32(dr["user_type"])==1)
                {
                    var frm = new FrmMainForm();
                    var dia = frm.ShowDialog();
                    if (dia == DialogResult.OK)
                    {
                        this.Show();
                        this.timerCard.Stop();
                    }
                    else
                    {
                        this.Close();
                        this.timerCard.Stop();
                    }
                }
                else
                {
                    var frm = new FrmMainFormS();
                    var dia = frm.ShowDialog();
                    if (dia == DialogResult.OK)
                    {
                        this.Show();
                        this.timerCard.Stop();
                    }
                    else
                    {
                        this.Close();
                        this.timerCard.Stop();
                    }
                }
               
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
                this.txtUserPwd.Text = "";
                return;
            }
            this.timerCard.Start();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //this.timerCard.Stop();
            this.Hide();
            var frm = new FrmRegister();
            frm.ShowDialog();
            this.Show();
            //this.timerCard.Start();
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timerCard.Stop();
        }

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAuto.Checked == true)
            {
                this.chkRem.Checked = true;
            }
        }

        private void chkRem_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkRem.Checked == false)
            {
                this.chkAuto.Checked = false;
            }
        }

        private void picbQR_MouseClick(object sender, MouseEventArgs e)
        {
            this.timerCard.Stop();
            this.Hide();
            if (new FrmQRCode().ShowDialog() == DialogResult.OK)
            {
                if (new FrmMainForm().ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this.Show();
            }
            this.timerCard.Start();

        }

        private void txtUserNo_EditValueChanged(object sender, EventArgs e)
        {
            var user_no = this.txtUserNo.Text.Trim();
            if (user_no != "")
            {
                var dt = $@"select * from UserInfo where user_no=@user_no".ExecuteQuery(("@user_no", user_no));
                if (dt != null && dt.Rows.Count > 0)
                {
                    var dr = dt.Rows[0];
                    var photo = dr["photo"];
                    if (photo != null && photo != DBNull.Value)
                    {
                        var photo_str = photo.ToString();
                        if (photo_str != "")
                        {
                            var photo_bytes = Convert.FromBase64String(photo.ToString()); //注意：JSON反序列化成DataTable时，byte[]默认反序列化为Base64字符串
                            this.picbhead.Image = Image.FromStream(new MemoryStream(photo_bytes));
                            return;
                        }
                        else
                        {
                            this.picbhead.Image = Resources.lylh;
                            return;
                        }
                    }
                    else
                    {
                        this.picbhead.Image = Resources.lylh;
                        return;
                    }
                }
                else
                {
                    this.picbhead.Image = Resources.lylh;
                    return;
                }
            }
            else
            {
                this.picbhead.Image = Resources.lylh;
                return;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            var FilePath = AppDomain.CurrentDomain.BaseDirectory + "user.json";
            if (File.Exists(FilePath))
            {

                dynamic dia = JsonConvert.DeserializeObject(File.ReadAllText(FilePath));
                var user_no = dia.user_no;
                var user_pwd = dia.user_pwd;
                var is_rem = dia.is_rem;
                var is_auto = dia.is_auto;

                this.txtUserNo.Text = user_no;
                this.txtUserPwd.Text = user_pwd;
                this.chkAuto.Checked = is_auto;
                this.chkRem.Checked = is_rem;
                if (is_auto == true)
                {
                    btnLogin_Click(null, null);
                }

            }
        }

        
    }
}
