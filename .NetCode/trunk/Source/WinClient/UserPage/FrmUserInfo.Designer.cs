
namespace WinClient
{
    partial class FrmUserInfo
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
            this.lblCellPhoneNum = new DevExpress.XtraEditors.LabelControl();
            this.txtCellPhoneNum = new DevExpress.XtraEditors.TextEdit();
            this.txtBrithday = new DevExpress.XtraEditors.TextEdit();
            this.lblBirthday = new DevExpress.XtraEditors.LabelControl();
            this.lblBirth = new DevExpress.XtraEditors.LabelControl();
            this.txtDE = new DevExpress.XtraEditors.DateEdit();
            this.lblSex = new DevExpress.XtraEditors.LabelControl();
            this.cmbSex = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtAge = new DevExpress.XtraEditors.TextEdit();
            this.lblAge = new DevExpress.XtraEditors.LabelControl();
            this.picb = new DevExpress.XtraEditors.PictureEdit();
            this.txtQqNum = new DevExpress.XtraEditors.TextEdit();
            this.lblQqNum = new DevExpress.XtraEditors.LabelControl();
            this.lblUserNo = new DevExpress.XtraEditors.LabelControl();
            this.txtUserNo = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.txtWeChatNo = new DevExpress.XtraEditors.TextEdit();
            this.lblWeChatNo = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectPhoto = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtCellPhoneNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrithday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDE.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQqNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeChatNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCellPhoneNum
            // 
            this.lblCellPhoneNum.Location = new System.Drawing.Point(116, 373);
            this.lblCellPhoneNum.Name = "lblCellPhoneNum";
            this.lblCellPhoneNum.Size = new System.Drawing.Size(60, 22);
            this.lblCellPhoneNum.TabIndex = 0;
            this.lblCellPhoneNum.Text = "手机号:";
            // 
            // txtCellPhoneNum
            // 
            this.txtCellPhoneNum.Location = new System.Drawing.Point(183, 373);
            this.txtCellPhoneNum.Name = "txtCellPhoneNum";
            this.txtCellPhoneNum.Size = new System.Drawing.Size(201, 28);
            this.txtCellPhoneNum.TabIndex = 1;
            // 
            // txtBrithday
            // 
            this.txtBrithday.Location = new System.Drawing.Point(183, 445);
            this.txtBrithday.Name = "txtBrithday";
            this.txtBrithday.Size = new System.Drawing.Size(201, 28);
            this.txtBrithday.TabIndex = 3;
            // 
            // lblBirthday
            // 
            this.lblBirthday.Location = new System.Drawing.Point(133, 448);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(42, 22);
            this.lblBirthday.TabIndex = 2;
            this.lblBirthday.Text = "生日:";
            // 
            // lblBirth
            // 
            this.lblBirth.Location = new System.Drawing.Point(89, 519);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(90, 22);
            this.lblBirth.TabIndex = 4;
            this.lblBirth.Text = "出生日期：";
            // 
            // txtDE
            // 
            this.txtDE.EditValue = null;
            this.txtDE.Location = new System.Drawing.Point(183, 516);
            this.txtDE.Name = "txtDE";
            this.txtDE.Properties.BeepOnError = false;
            this.txtDE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDE.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDE.Properties.MaskSettings.Set("mask", "D");
            this.txtDE.Size = new System.Drawing.Size(201, 28);
            this.txtDE.TabIndex = 6;
            this.txtDE.EditValueChanged += new System.EventHandler(this.DE_EditValueChanged);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(513, 299);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(42, 22);
            this.lblSex.TabIndex = 7;
            this.lblSex.Text = "性别:";
            // 
            // cmbSex
            // 
            this.cmbSex.EditValue = "男";
            this.cmbSex.Location = new System.Drawing.Point(573, 299);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSex.Properties.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cmbSex.Size = new System.Drawing.Size(201, 28);
            this.cmbSex.TabIndex = 8;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(573, 371);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(201, 28);
            this.txtAge.TabIndex = 10;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(513, 374);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(42, 22);
            this.lblAge.TabIndex = 9;
            this.lblAge.Text = "年龄:";
            // 
            // picb
            // 
            this.picb.Location = new System.Drawing.Point(75, 31);
            this.picb.Name = "picb";
            this.picb.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picb.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picb.Size = new System.Drawing.Size(377, 329);
            this.picb.TabIndex = 11;
            this.picb.EditValueChanged += new System.EventHandler(this.pictureEdit1_EditValueChanged);
            this.picb.DoubleClick += new System.EventHandler(this.picb_DoubleClick);
            // 
            // txtQqNum
            // 
            this.txtQqNum.Location = new System.Drawing.Point(573, 442);
            this.txtQqNum.Name = "txtQqNum";
            this.txtQqNum.Size = new System.Drawing.Size(201, 28);
            this.txtQqNum.TabIndex = 13;
            // 
            // lblQqNum
            // 
            this.lblQqNum.Location = new System.Drawing.Point(513, 445);
            this.lblQqNum.Name = "lblQqNum";
            this.lblQqNum.Size = new System.Drawing.Size(50, 22);
            this.lblQqNum.TabIndex = 12;
            this.lblQqNum.Text = "QQ号:";
            // 
            // lblUserNo
            // 
            this.lblUserNo.Location = new System.Drawing.Point(501, 48);
            this.lblUserNo.Name = "lblUserNo";
            this.lblUserNo.Size = new System.Drawing.Size(60, 22);
            this.lblUserNo.TabIndex = 14;
            this.lblUserNo.Text = "用户名:";
            // 
            // txtUserNo
            // 
            this.txtUserNo.Location = new System.Drawing.Point(573, 44);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Size = new System.Drawing.Size(201, 28);
            this.txtUserNo.TabIndex = 15;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(573, 110);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(201, 28);
            this.txtUserName.TabIndex = 17;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(488, 114);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(78, 22);
            this.lblUserName.TabIndex = 16;
            this.lblUserName.Text = "用户姓名:";
            // 
            // txtWeChatNo
            // 
            this.txtWeChatNo.Location = new System.Drawing.Point(573, 195);
            this.txtWeChatNo.Name = "txtWeChatNo";
            this.txtWeChatNo.Size = new System.Drawing.Size(201, 28);
            this.txtWeChatNo.TabIndex = 19;
            // 
            // lblWeChatNo
            // 
            this.lblWeChatNo.Location = new System.Drawing.Point(501, 197);
            this.lblWeChatNo.Name = "lblWeChatNo";
            this.lblWeChatNo.Size = new System.Drawing.Size(60, 22);
            this.lblWeChatNo.TabIndex = 18;
            this.lblWeChatNo.Text = "微信号:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(238, 670);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 35);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "保存";
            // 
            // btnSelectPhoto
            // 
            this.btnSelectPhoto.Location = new System.Drawing.Point(394, 670);
            this.btnSelectPhoto.Name = "btnSelectPhoto";
            this.btnSelectPhoto.Size = new System.Drawing.Size(111, 35);
            this.btnSelectPhoto.TabIndex = 21;
            this.btnSelectPhoto.Text = "选择图片";
            this.btnSelectPhoto.Click += new System.EventHandler(this.btnSelectPhoto_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(560, 670);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 35);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 782);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSelectPhoto);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtWeChatNo);
            this.Controls.Add(this.lblWeChatNo);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtUserNo);
            this.Controls.Add(this.lblUserNo);
            this.Controls.Add(this.txtQqNum);
            this.Controls.Add(this.lblQqNum);
            this.Controls.Add(this.picb);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.cmbSex);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.txtDE);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.txtBrithday);
            this.Controls.Add(this.lblBirthday);
            this.Controls.Add(this.txtCellPhoneNum);
            this.Controls.Add(this.lblCellPhoneNum);
            this.Name = "FrmUserInfo";
            this.Text = "FrmUserInfo";
            ((System.ComponentModel.ISupportInitialize)(this.txtCellPhoneNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrithday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDE.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQqNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeChatNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblCellPhoneNum;
        private DevExpress.XtraEditors.TextEdit txtCellPhoneNum;
        private DevExpress.XtraEditors.TextEdit txtBrithday;
        private DevExpress.XtraEditors.LabelControl lblBirthday;
        private DevExpress.XtraEditors.LabelControl lblBirth;
        private DevExpress.XtraEditors.DateEdit txtDE;
        private DevExpress.XtraEditors.LabelControl lblSex;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSex;
        private DevExpress.XtraEditors.TextEdit txtAge;
        private DevExpress.XtraEditors.LabelControl lblAge;
        private DevExpress.XtraEditors.PictureEdit picb;
        private DevExpress.XtraEditors.TextEdit txtQqNum;
        private DevExpress.XtraEditors.LabelControl lblQqNum;
        private DevExpress.XtraEditors.LabelControl lblUserNo;
        private DevExpress.XtraEditors.TextEdit txtUserNo;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraEditors.TextEdit txtWeChatNo;
        private DevExpress.XtraEditors.LabelControl lblWeChatNo;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnSelectPhoto;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}