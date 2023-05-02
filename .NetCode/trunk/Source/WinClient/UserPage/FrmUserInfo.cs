using DevExpress.XtraEditors;
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

using WinClient.Helper;

using WinClient.Properties;

namespace WinClient
{
    public partial class FrmUserInfo : XtraForm
    {
        bool enable;
        public FrmUserInfo()
        {
            InitializeComponent();
            var dt = $@"select * from UserInfo where guid=@user_guid".ExecuteQuery(("@user_guid", Program.user_guid));
            var dr = dt.Rows[0];
            //txtDE.Text = Convert.ToString(dr["birth"]);
            txtUserNo.Text = Convert.ToString(dr["user_no"]);
            txtQqNum.Text = Convert.ToString(dr["qq_no"]);
            txtWeChatNo.Text = Convert.ToString(dr["webchat_no"]);
            txtUserName.Text = Convert.ToString(dr["user_name"]);
            txtCellPhoneNum.Text = Convert.ToString(dr["mobile"]);
            txtAge.ReadOnly = true;
            txtBrithday.ReadOnly = true;
            var photo = dr["photo"];
            if (photo != null && photo != DBNull.Value)
            {
                var photo_str = photo.ToString();
                if (photo_str != "")
                {
                    enable = false;
                    var photo_bytes = Convert.FromBase64String(photo.ToString()); //注意：JSON反序列化成DataTable时，byte[]默认反序列化为Base64字符串
                    this.picb.Image = Image.FromStream(new MemoryStream(photo_bytes));
                    return;
                }
                else
                {
                    enable = false;
                    this.picb.Image = Resources.lylh;
                    return;
                }
            }
            else
            {
                enable = false;
                this.picb.Image = Resources.lylh;
                return;
            }

        }

        private void DE_EditValueChanged(object sender, EventArgs e)
        {
            if (txtDE.Text == "")
            {
                return;
            }
            int day = Convert.ToInt32(txtDE.Text.Remove(4));
            int date = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            DateTime dt = DateTime.Now;
            var time = dt.CompareTo(Convert.ToDateTime(txtDE.Text));
            if (time == -1)
            {
                MessageBox.Show("出生日期不能大于当前日期");
                txtDE.Text = "";
                txtAge.Text = "";
                txtBrithday.Text = "";
                return;
            }
            txtBrithday.Text = txtDE.Text.Remove(0, 5);
            txtAge.Text = Convert.ToString(date - day);

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (enable == false)
            {
                return;
            }
            var photo = picb.Image;
            byte[] PhotoBytes = null;
            if (photo != null)
            {
                using (var ms = new MemoryStream())
                {
                    photo.Save(ms, ImageFormat.Bmp);
                    PhotoBytes = ms.ToArray();
                }
            }
            $@"update UserInfo set photo=@PhotoBytes where guid=@guid".ExecuteNonQuery(("@PhotoBytes", PhotoBytes, typeof(byte[]).FullName), ("@guid", Program.user_guid, typeof(string).FullName));
            MessageBox.Show("修改成功,请重新登录");
        }
        /// <summary>
        /// 图片控件双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picb_DoubleClick(object sender, EventArgs e)
        {
            enable = true;
            this.picb.ShowTakePictureDialog();
        }
        /// <summary>
        /// 选择图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
