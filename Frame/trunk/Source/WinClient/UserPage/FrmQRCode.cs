using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinClient
{
    public partial class FrmQRCode : Form
    {
        /// <summary>
        /// 二维码窗体
        /// </summary>
        public FrmQRCode()
        {
            InitializeComponent();
            #region 常用代码
            AutoScaleMode = AutoScaleMode.None;//窗体自动缩放
            FormBorderStyle = FormBorderStyle.FixedSingle;//设置边框样式
            MaximizeBox = false;//禁止最大化
            StartPosition = FormStartPosition.CenterScreen;//窗体居中
            #endregion
        }
        string barcode = "";
        public void LoadBarCode()
        {
            var dt = SqlHelper.ExecuteQuery($@"select top 1 * from BarCodeInfo order by ruid desc");

            if (dt != null && dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
                var qrcode = Convert.ToString(dr["barcode"]);
                var barcode_guid = Convert.ToString(dr["guid"]);
                if (qrcode == barcode)
                {
                    Program.user_guid = Convert.ToString(dr["user_guid"]);
                    "insert into LogInfo(barcode_guid,user_guid,log_type)values(@barcode_guid,@user_guid,@log_type)".ExecuteNonQuery(("@barcode_guid", barcode_guid,typeof(string).FullName),("@user_guid", Program.user_guid, typeof(string).FullName),("@log_type", "扫码登录",typeof(string).FullName));
                    this.Hide();
                    var frm = new FrmMainForm();
                    timerQR.Stop();
                    var dia = frm.ShowDialog();
                    if (dia == DialogResult.OK)
                    {
                        this.ShowDialog();
                    }
                    else
                    {
                        this.Close();
                    }

                }
                else
                {
                    return;
                }

            }
        }

        private void timerQR_Tick(object sender, EventArgs e)
        {
            LoadBarCode();
        }

        private void FrmQRCode_Load(object sender, EventArgs e)
        {
             barcode = Guid.NewGuid().ToString();
            this.barCodeControl.Text = barcode;
            this.timerQR.Start();
        }

        private void FrmQRCode_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timerQR.Stop();
        }

        private void barCodeControl_Click(object sender, EventArgs e)
        {
             barcode = Guid.NewGuid().ToString();
            this.barCodeControl.Text = barcode;
        }
    }
}
