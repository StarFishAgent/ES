
namespace WinClient
{
    /// <summary>
    /// 添加题目类型窗体
    /// </summary>
    partial class FrmExamAddType
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
            this.lblExamType = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddYear = new DevExpress.XtraEditors.SimpleButton();
            this.cmbExamType = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbExamType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblExamType
            // 
            this.lblExamType.Location = new System.Drawing.Point(27, 57);
            this.lblExamType.Name = "lblExamType";
            this.lblExamType.Size = new System.Drawing.Size(60, 14);
            this.lblExamType.TabIndex = 0;
            this.lblExamType.Text = "考试类型：";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(41, 115);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 27);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddYear
            // 
            this.btnAddYear.Location = new System.Drawing.Point(155, 115);
            this.btnAddYear.Name = "btnAddYear";
            this.btnAddYear.Size = new System.Drawing.Size(99, 27);
            this.btnAddYear.TabIndex = 3;
            this.btnAddYear.Text = "一键添加年份";
            this.btnAddYear.Click += new System.EventHandler(this.btnAddYear_Click);
            // 
            // cmbExamType
            // 
            this.cmbExamType.Location = new System.Drawing.Point(105, 57);
            this.cmbExamType.Name = "cmbExamType";
            this.cmbExamType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbExamType.Size = new System.Drawing.Size(149, 20);
            this.cmbExamType.TabIndex = 4;
            // 
            // FrmExamAddType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 177);
            this.Controls.Add(this.cmbExamType);
            this.Controls.Add(this.btnAddYear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblExamType);
            this.Name = "FrmExamAddType";
            this.Text = "添加考试类型";
            ((System.ComponentModel.ISupportInitialize)(this.cmbExamType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblExamType;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnAddYear;
        private DevExpress.XtraEditors.ComboBoxEdit cmbExamType;
    }
}