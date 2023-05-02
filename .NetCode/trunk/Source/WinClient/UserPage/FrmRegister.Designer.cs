
namespace WinClient
{
    /// <summary>
    /// 注册窗体
    /// </summary>
    partial class FrmRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblCardNo = new DevExpress.XtraEditors.LabelControl();
            this.lblUserNo = new DevExpress.XtraEditors.LabelControl();
            this.lblUserPwd = new DevExpress.XtraEditors.LabelControl();
            this.lblUserRePwd = new DevExpress.XtraEditors.LabelControl();
            this.btnRegister = new DevExpress.XtraEditors.SimpleButton();
            this.btnCencel = new DevExpress.XtraEditors.SimpleButton();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.btnTakePhotos = new DevExpress.XtraEditors.SimpleButton();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.picb = new DevExpress.XtraEditors.PictureEdit();
            this.txtUserRePwd = new DevExpress.XtraEditors.TextEdit();
            this.txtUserPwd = new DevExpress.XtraEditors.TextEdit();
            this.txtUserNo = new DevExpress.XtraEditors.TextEdit();
            this.txtCardNo = new DevExpress.XtraEditors.TextEdit();
            this.lblSex = new DevExpress.XtraEditors.LabelControl();
            this.timerCard = new System.Windows.Forms.Timer(this.components);
            this.cmbSex = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserRePwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSex.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCardNo
            // 
            this.lblCardNo.Location = new System.Drawing.Point(443, 19);
            this.lblCardNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(54, 22);
            this.lblCardNo.TabIndex = 0;
            this.lblCardNo.Text = "卡号：";
            // 
            // lblUserNo
            // 
            this.lblUserNo.Location = new System.Drawing.Point(426, 97);
            this.lblUserNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblUserNo.Name = "lblUserNo";
            this.lblUserNo.Size = new System.Drawing.Size(72, 22);
            this.lblUserNo.TabIndex = 1;
            this.lblUserNo.Text = "用户名：";
            // 
            // lblUserPwd
            // 
            this.lblUserPwd.Location = new System.Drawing.Point(426, 174);
            this.lblUserPwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblUserPwd.Name = "lblUserPwd";
            this.lblUserPwd.Size = new System.Drawing.Size(90, 22);
            this.lblUserPwd.TabIndex = 4;
            this.lblUserPwd.Text = "用户密码：";
            // 
            // lblUserRePwd
            // 
            this.lblUserRePwd.Location = new System.Drawing.Point(426, 250);
            this.lblUserRePwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblUserRePwd.Name = "lblUserRePwd";
            this.lblUserRePwd.Size = new System.Drawing.Size(90, 22);
            this.lblUserRePwd.TabIndex = 5;
            this.lblUserRePwd.Text = "确认密码：";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(200, 512);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(124, 42);
            this.btnRegister.TabIndex = 11;
            this.btnRegister.Text = "注册";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCencel
            // 
            this.btnCencel.Location = new System.Drawing.Point(430, 512);
            this.btnCencel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCencel.Name = "btnCencel";
            this.btnCencel.Size = new System.Drawing.Size(124, 42);
            this.btnCencel.TabIndex = 12;
            this.btnCencel.Text = "取消";
            this.btnCencel.Click += new System.EventHandler(this.btnCencel_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(423, 327);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(90, 22);
            this.lblUserName.TabIndex = 11;
            this.lblUserName.Text = "用户姓名：";
            // 
            // btnTakePhotos
            // 
            this.btnTakePhotos.Location = new System.Drawing.Point(129, 377);
            this.btnTakePhotos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTakePhotos.Name = "btnTakePhotos";
            this.btnTakePhotos.Size = new System.Drawing.Size(107, 36);
            this.btnTakePhotos.TabIndex = 10;
            this.btnTakePhotos.Text = "拍照";
            this.btnTakePhotos.Click += new System.EventHandler(this.btnTakePhotos_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(554, 327);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(167, 28);
            this.txtUserName.TabIndex = 8;
            // 
            // picb
            // 
            this.picb.Location = new System.Drawing.Point(37, 39);
            this.picb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picb.Name = "picb";
            this.picb.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picb.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picb.Size = new System.Drawing.Size(287, 294);
            this.picb.TabIndex = 10;
            this.picb.DoubleClick += new System.EventHandler(this.picb_DoubleClick);
            // 
            // txtUserRePwd
            // 
            this.txtUserRePwd.Location = new System.Drawing.Point(554, 245);
            this.txtUserRePwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserRePwd.Name = "txtUserRePwd";
            this.txtUserRePwd.Properties.PasswordChar = '*';
            this.txtUserRePwd.Size = new System.Drawing.Size(167, 28);
            this.txtUserRePwd.TabIndex = 7;
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.Location = new System.Drawing.Point(554, 174);
            this.txtUserPwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.Properties.PasswordChar = '*';
            this.txtUserPwd.Size = new System.Drawing.Size(167, 28);
            this.txtUserPwd.TabIndex = 6;
            // 
            // txtUserNo
            // 
            this.txtUserNo.Location = new System.Drawing.Point(554, 97);
            this.txtUserNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Size = new System.Drawing.Size(167, 28);
            this.txtUserNo.TabIndex = 3;
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(554, 19);
            this.txtCardNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(167, 28);
            this.txtCardNo.TabIndex = 2;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(443, 410);
            this.lblSex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(54, 22);
            this.lblSex.TabIndex = 14;
            this.lblSex.Text = "性别：";
            // 
            // timerCard
            // 
            this.timerCard.Tick += new System.EventHandler(this.timerCard_Tick);
            // 
            // cmbSex
            // 
            this.cmbSex.Location = new System.Drawing.Point(554, 405);
            this.cmbSex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSex.Properties.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cmbSex.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbSex.Size = new System.Drawing.Size(167, 28);
            this.cmbSex.TabIndex = 15;
            // 
            // FrmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 600);
            this.Controls.Add(this.cmbSex);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.btnTakePhotos);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picb);
            this.Controls.Add(this.btnCencel);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtUserRePwd);
            this.Controls.Add(this.txtUserPwd);
            this.Controls.Add(this.lblUserRePwd);
            this.Controls.Add(this.lblUserPwd);
            this.Controls.Add(this.txtUserNo);
            this.Controls.Add(this.txtCardNo);
            this.Controls.Add(this.lblUserNo);
            this.Controls.Add(this.lblCardNo);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmRegister";
            this.Text = "用户注册";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRegister_FormClosing);
            this.Load += new System.EventHandler(this.FrmRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserRePwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSex.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblCardNo;
        private DevExpress.XtraEditors.LabelControl lblUserNo;
        private DevExpress.XtraEditors.TextEdit txtCardNo;
        private DevExpress.XtraEditors.TextEdit txtUserNo;
        private DevExpress.XtraEditors.LabelControl lblUserPwd;
        private DevExpress.XtraEditors.LabelControl lblUserRePwd;
        private DevExpress.XtraEditors.TextEdit txtUserPwd;
        private DevExpress.XtraEditors.TextEdit txtUserRePwd;
        private DevExpress.XtraEditors.SimpleButton btnRegister;
        private DevExpress.XtraEditors.SimpleButton btnCencel;
        private DevExpress.XtraEditors.PictureEdit picb;
        private DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.SimpleButton btnTakePhotos;
        private DevExpress.XtraEditors.LabelControl lblSex;
        private System.Windows.Forms.Timer timerCard;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSex;
    }
}