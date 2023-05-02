
namespace WinClient
{
    /// <summary>
    /// 添加考试信息窗体
    /// </summary>
    partial class FrmExamAddExamNameInfo
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnAddYear = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.cmbExamYear = new DevExpress.XtraEditors.DateEdit();
            this.lblExamName = new DevExpress.XtraEditors.LabelControl();
            this.txtExamName = new DevExpress.XtraEditors.TextEdit();
            this.lblExamType = new DevExpress.XtraEditors.LabelControl();
            this.cmbExamType = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbExamYear.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbExamYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExamName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbExamType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(42, 130);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "考试时间:";
            // 
            // btnAddYear
            // 
            this.btnAddYear.Location = new System.Drawing.Point(40, 192);
            this.btnAddYear.Name = "btnAddYear";
            this.btnAddYear.Size = new System.Drawing.Size(107, 27);
            this.btnAddYear.TabIndex = 4;
            this.btnAddYear.Text = "添加考试信息";
            this.btnAddYear.Click += new System.EventHandler(this.btnAddYear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(182, 192);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 27);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbExamYear
            // 
            this.cmbExamYear.EditValue = null;
            this.cmbExamYear.Location = new System.Drawing.Point(113, 127);
            this.cmbExamYear.Name = "cmbExamYear";
            this.cmbExamYear.Properties.BeepOnError = false;
            this.cmbExamYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbExamYear.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbExamYear.Properties.MaskSettings.Set("mask", "D");
            this.cmbExamYear.Size = new System.Drawing.Size(142, 20);
            this.cmbExamYear.TabIndex = 3;
            // 
            // lblExamName
            // 
            this.lblExamName.Location = new System.Drawing.Point(40, 28);
            this.lblExamName.Name = "lblExamName";
            this.lblExamName.Size = new System.Drawing.Size(52, 14);
            this.lblExamName.TabIndex = 8;
            this.lblExamName.Text = "考试名称:";
            // 
            // txtExamName
            // 
            this.txtExamName.Location = new System.Drawing.Point(111, 25);
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.Size = new System.Drawing.Size(142, 20);
            this.txtExamName.TabIndex = 1;
            // 
            // lblExamType
            // 
            this.lblExamType.Location = new System.Drawing.Point(40, 80);
            this.lblExamType.Name = "lblExamType";
            this.lblExamType.Size = new System.Drawing.Size(52, 14);
            this.lblExamType.TabIndex = 10;
            this.lblExamType.Text = "考试类型:";
            // 
            // cmbExamType
            // 
            this.cmbExamType.Location = new System.Drawing.Point(113, 77);
            this.cmbExamType.Name = "cmbExamType";
            this.cmbExamType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbExamType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbExamType.Size = new System.Drawing.Size(142, 20);
            this.cmbExamType.TabIndex = 2;
            // 
            // FrmExamAddExamNameInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 254);
            this.Controls.Add(this.cmbExamType);
            this.Controls.Add(this.lblExamType);
            this.Controls.Add(this.txtExamName);
            this.Controls.Add(this.lblExamName);
            this.Controls.Add(this.cmbExamYear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddYear);
            this.Controls.Add(this.labelControl2);
            this.Name = "FrmExamAddExamNameInfo";
            this.Text = "添加历年考试信息";
            ((System.ComponentModel.ISupportInitialize)(this.cmbExamYear.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbExamYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExamName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbExamType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnAddYear;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.DateEdit cmbExamYear;
        private DevExpress.XtraEditors.LabelControl lblExamName;
        private DevExpress.XtraEditors.TextEdit txtExamName;
        private DevExpress.XtraEditors.LabelControl lblExamType;
        private DevExpress.XtraEditors.ComboBoxEdit cmbExamType;
    }
}