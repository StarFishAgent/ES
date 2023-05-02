
namespace WinClient
{
    /// <summary>
    /// 添加题目窗体
    /// </summary>
    partial class FrmExamAddTitle
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
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblYear = new DevExpress.XtraEditors.LabelControl();
            this.lblExamType = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.btnclear = new DevExpress.XtraEditors.SimpleButton();
            this.lblExamName = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtExamTime = new DevExpress.XtraEditors.TextEdit();
            this.txtExamType = new DevExpress.XtraEditors.TextEdit();
            this.txtExamName = new DevExpress.XtraEditors.TextEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnScan = new DevExpress.XtraEditors.SimpleButton();
            this.richBoxEdit1 = new WinControl.MyControl.RichBoxEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExamTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExamType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExamName.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(0, 132);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(135, 33);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "题目名称：";
            // 
            // lblYear
            // 
            this.lblYear.Location = new System.Drawing.Point(21, 39);
            this.lblYear.Margin = new System.Windows.Forms.Padding(4);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(60, 14);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "考试时间：";
            // 
            // lblExamType
            // 
            this.lblExamType.Location = new System.Drawing.Point(246, 39);
            this.lblExamType.Margin = new System.Windows.Forms.Padding(4);
            this.lblExamType.Name = "lblExamType";
            this.lblExamType.Size = new System.Drawing.Size(60, 14);
            this.lblExamType.TabIndex = 6;
            this.lblExamType.Text = "考试类型：";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(33, 57);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 27);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(186, 57);
            this.btnCancle.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(88, 27);
            this.btnCancle.TabIndex = 9;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(318, 57);
            this.btnclear.Margin = new System.Windows.Forms.Padding(4);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(99, 27);
            this.btnclear.TabIndex = 10;
            this.btnclear.Text = "清空题目内容";
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // lblExamName
            // 
            this.lblExamName.Location = new System.Drawing.Point(490, 39);
            this.lblExamName.Margin = new System.Windows.Forms.Padding(4);
            this.lblExamName.Name = "lblExamName";
            this.lblExamName.Size = new System.Drawing.Size(60, 14);
            this.lblExamName.TabIndex = 12;
            this.lblExamName.Text = "考试名称：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtExamTime);
            this.panel1.Controls.Add(this.txtExamType);
            this.panel1.Controls.Add(this.txtExamName);
            this.panel1.Controls.Add(this.lblExamType);
            this.panel1.Controls.Add(this.lblYear);
            this.panel1.Controls.Add(this.lblExamName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1091, 125);
            this.panel1.TabIndex = 14;
            // 
            // txtExamTime
            // 
            this.txtExamTime.Location = new System.Drawing.Point(79, 39);
            this.txtExamTime.Name = "txtExamTime";
            this.txtExamTime.Properties.ReadOnly = true;
            this.txtExamTime.Size = new System.Drawing.Size(118, 20);
            this.txtExamTime.TabIndex = 15;
            // 
            // txtExamType
            // 
            this.txtExamType.Location = new System.Drawing.Point(310, 39);
            this.txtExamType.Name = "txtExamType";
            this.txtExamType.Properties.ReadOnly = true;
            this.txtExamType.Size = new System.Drawing.Size(124, 20);
            this.txtExamType.TabIndex = 14;
            // 
            // txtExamName
            // 
            this.txtExamName.Location = new System.Drawing.Point(557, 39);
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.Properties.ReadOnly = true;
            this.txtExamName.Size = new System.Drawing.Size(130, 20);
            this.txtExamName.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnScan);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnCancle);
            this.panel2.Controls.Add(this.btnclear);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 451);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1091, 117);
            this.panel2.TabIndex = 16;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(468, 57);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(82, 27);
            this.btnScan.TabIndex = 11;
            this.btnScan.Text = "识别图像文字";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // richBoxEdit1
            // 
            this.richBoxEdit1.Location = new System.Drawing.Point(125, 132);
            this.richBoxEdit1.Name = "richBoxEdit1";
            this.richBoxEdit1.Size = new System.Drawing.Size(942, 275);
            this.richBoxEdit1.TabIndex = 17;
            // 
            // FrmExamAddTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 568);
            this.Controls.Add(this.richBoxEdit1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmExamAddTitle";
            this.Text = "添加题目";
            this.Load += new System.EventHandler(this.FrmAddTitle_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExamTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExamType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExamName.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblYear;
        private DevExpress.XtraEditors.LabelControl lblExamType;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.SimpleButton btnclear;
        private DevExpress.XtraEditors.LabelControl lblExamName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.TextEdit txtExamName;
        private DevExpress.XtraEditors.TextEdit txtExamType;
        private DevExpress.XtraEditors.TextEdit txtExamTime;
        private DevExpress.XtraEditors.SimpleButton btnScan;
        private WinControl.MyControl.RichBoxEdit richBoxEdit1;
    }
}