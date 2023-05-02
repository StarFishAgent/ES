
namespace WinClient.UserPage
{
    /// <summary>
    /// 登录窗体
    /// </summary>
    partial class FrmLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblUserNo = new DevExpress.XtraEditors.LabelControl();
            this.lblUserPwd = new DevExpress.XtraEditors.LabelControl();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnRegister = new DevExpress.XtraEditors.SimpleButton();
            this.lblGet = new System.Windows.Forms.LinkLabel();
            this.timerCard = new System.Windows.Forms.Timer(this.components);
            this.picbhead = new DevExpress.XtraEditors.PictureEdit();
            this.chkRem = new DevExpress.XtraEditors.CheckEdit();
            this.chkAuto = new DevExpress.XtraEditors.CheckEdit();
            this.picbQR = new DevExpress.XtraEditors.PictureEdit();
            this.txtUserPwd = new DevExpress.XtraEditors.TextEdit();
            this.txtUserNo = new DevExpress.XtraEditors.TextEdit();
            this.picbLogo = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picbhead.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAuto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbQR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbLogo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserNo
            // 
            this.lblUserNo.Location = new System.Drawing.Point(33, 157);
            this.lblUserNo.Name = "lblUserNo";
            this.lblUserNo.Size = new System.Drawing.Size(40, 14);
            this.lblUserNo.TabIndex = 1;
            this.lblUserNo.Text = "用户名:";
            // 
            // lblUserPwd
            // 
            this.lblUserPwd.Location = new System.Drawing.Point(33, 218);
            this.lblUserPwd.Name = "lblUserPwd";
            this.lblUserPwd.Size = new System.Drawing.Size(36, 14);
            this.lblUserPwd.TabIndex = 2;
            this.lblUserPwd.Text = "密  码:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(40, 323);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(87, 27);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(191, 321);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(87, 27);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "注册";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblGet
            // 
            this.lblGet.AutoSize = true;
            this.lblGet.Location = new System.Drawing.Point(265, 275);
            this.lblGet.Name = "lblGet";
            this.lblGet.Size = new System.Drawing.Size(55, 14);
            this.lblGet.TabIndex = 10;
            this.lblGet.TabStop = true;
            this.lblGet.Text = "找回密码";
            // 
            // timerCard
            // 
            this.timerCard.Interval = 500;
            this.timerCard.Tick += new System.EventHandler(this.timerLogin_Tick);
            // 
            // picbhead
            // 
            this.picbhead.EditValue = global::WinClient.Properties.Resources.lylh;
            this.picbhead.Location = new System.Drawing.Point(297, 129);
            this.picbhead.Name = "picbhead";
            this.picbhead.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picbhead.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picbhead.Size = new System.Drawing.Size(100, 112);
            this.picbhead.TabIndex = 11;
            // 
            // chkRem
            // 
            this.chkRem.Location = new System.Drawing.Point(171, 272);
            this.chkRem.Name = "chkRem";
            this.chkRem.Properties.Caption = "记住密码";
            this.chkRem.Size = new System.Drawing.Size(87, 20);
            this.chkRem.TabIndex = 9;
            this.chkRem.CheckedChanged += new System.EventHandler(this.chkRem_CheckedChanged);
            // 
            // chkAuto
            // 
            this.chkAuto.Location = new System.Drawing.Point(40, 272);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Properties.Caption = "自动登录";
            this.chkAuto.Size = new System.Drawing.Size(87, 20);
            this.chkAuto.TabIndex = 8;
            this.chkAuto.CheckedChanged += new System.EventHandler(this.chkAuto_CheckedChanged);
            // 
            // picbQR
            // 
            this.picbQR.EditValue = global::WinClient.Properties.Resources.ewm;
            this.picbQR.Location = new System.Drawing.Point(407, 334);
            this.picbQR.Name = "picbQR";
            this.picbQR.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picbQR.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picbQR.Size = new System.Drawing.Size(53, 54);
            this.picbQR.TabIndex = 7;
            this.picbQR.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picbQR_MouseClick);
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.EditValue = "1";
            this.txtUserPwd.Location = new System.Drawing.Point(123, 211);
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.Properties.PasswordChar = '*';
            this.txtUserPwd.Size = new System.Drawing.Size(117, 20);
            this.txtUserPwd.TabIndex = 4;
            // 
            // txtUserNo
            // 
            this.txtUserNo.EditValue = "2";
            this.txtUserNo.Location = new System.Drawing.Point(123, 149);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Size = new System.Drawing.Size(117, 20);
            this.txtUserNo.TabIndex = 3;
            this.txtUserNo.EditValueChanged += new System.EventHandler(this.txtUserNo_EditValueChanged);
            // 
            // picbLogo
            // 
            this.picbLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.picbLogo.EditValue = global::WinClient.Properties.Resources.pmh;
            this.picbLogo.Location = new System.Drawing.Point(0, 0);
            this.picbLogo.Name = "picbLogo";
            this.picbLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picbLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picbLogo.Size = new System.Drawing.Size(465, 111);
            this.picbLogo.TabIndex = 0;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 391);
            this.Controls.Add(this.picbhead);
            this.Controls.Add(this.lblGet);
            this.Controls.Add(this.chkRem);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.picbQR);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUserPwd);
            this.Controls.Add(this.txtUserNo);
            this.Controls.Add(this.lblUserPwd);
            this.Controls.Add(this.lblUserNo);
            this.Controls.Add(this.picbLogo);
            this.Name = "FrmLogin";
            this.Text = "登录窗体";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picbhead.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAuto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbQR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbLogo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picbLogo;
        private DevExpress.XtraEditors.LabelControl lblUserNo;
        private DevExpress.XtraEditors.LabelControl lblUserPwd;
        private DevExpress.XtraEditors.TextEdit txtUserNo;
        private DevExpress.XtraEditors.TextEdit txtUserPwd;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnRegister;
        private DevExpress.XtraEditors.PictureEdit picbQR;
        private DevExpress.XtraEditors.CheckEdit chkAuto;
        private DevExpress.XtraEditors.CheckEdit chkRem;
        private System.Windows.Forms.LinkLabel lblGet;
        private System.Windows.Forms.Timer timerCard;
        private DevExpress.XtraEditors.PictureEdit picbhead;
    }
}

