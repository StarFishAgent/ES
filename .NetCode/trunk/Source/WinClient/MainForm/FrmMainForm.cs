using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using WinClient.UserPage;
using WinClient.Helper;

namespace WinClient
{
    public partial class FrmMainForm : XtraForm
    {
        /// <summary>
        /// 主窗体
        /// </summary>
        public FrmMainForm()
        {
            InitializeComponent();
            #region 常用代码
            AutoScaleMode = AutoScaleMode.None;//窗体自动缩放
            FormBorderStyle = FormBorderStyle.FixedSingle;//设置边框样式
            MaximizeBox = false;//禁止最大化
            StartPosition = FormStartPosition.CenterScreen;//窗体居中
            #endregion
        }
        #region 窗体
        /// <summary>
        /// 加载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMainForm_Load(object sender, EventArgs e)
        {
            //btnUser.Enabled = false;
            btnUser.Caption = "欢迎回来  " + Program.user_no;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion
        #region 菜单
        /// <summary>
        /// 试题集按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllType_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            foreach (var frmchild in MdiChildren)
            {
                if (frmchild.GetType().FullName == typeof(FrmExamTypeList).FullName)
                {
                    frmchild.Activate();
                    return;
                }
            }
            var frm = new FrmExamTypeList();
            frm.MdiParent = this;
            frm.Show();
        }
        /// <summary>
        /// 添加类型按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddExamType_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var frm = new FrmExamAddType();
            frm.ShowDialog();
        }
        /// <summary>
        /// 添加考试信息按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddExamInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var frm = new FrmExamAddExamNameInfo();
            frm.ShowDialog();
        }


        #endregion
        #region Barmanage
        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var json = AppDomain.CurrentDomain.BaseDirectory + "user.json";
            var dic = File.ReadAllText(json).ToDynamic();
            dic.is_auto = false;
            File.WriteAllText(json, JsonConvert.SerializeObject(dic));
            this.Dispose();
            var frm = new FrmLogin();
            frm.ShowDialog();
            frm.Dispose();
        }
        /// <summary>
        /// 切换用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var json = AppDomain.CurrentDomain.BaseDirectory + "user.json";
            var dic = File.ReadAllText(json).ToDynamic();
            dic.is_auto = false;
            File.WriteAllText(json, JsonConvert.SerializeObject(dic));
            this.Hide();
            var frm = new FrmLogin();
            frm.ShowDialog();
        }
        /// <summary>
        /// 用户信息管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion

        private void btnUser_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmUserInfo();
            frm.ShowDialog();
            frm.Close();
        }
    }
}
