
namespace WinControl.MyControl
{
    partial class ControlAnswer
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.richBoxEdit2 = new WinControl.MyControl.RichBoxEdit();
            this.richEditControl1 = new WinControl.MyControl.RichBoxEdit();
            this.lblAnalysis = new DevExpress.XtraEditors.LabelControl();
            this.lblAnswer = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.richBoxEdit2);
            this.panelControl1.Controls.Add(this.richEditControl1);
            this.panelControl1.Controls.Add(this.lblAnalysis);
            this.panelControl1.Controls.Add(this.lblAnswer);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1043, 310);
            this.panelControl1.TabIndex = 11;
            // 
            // richBoxEdit2
            // 
            this.richBoxEdit2.Location = new System.Drawing.Point(150, 141);
            this.richBoxEdit2.Name = "richBoxEdit2";
            this.richBoxEdit2.Size = new System.Drawing.Size(888, 166);
            this.richBoxEdit2.TabIndex = 3;
            // 
            // richEditControl1
            // 
            this.richEditControl1.Location = new System.Drawing.Point(150, 7);
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.Size = new System.Drawing.Size(888, 128);
            this.richEditControl1.TabIndex = 2;
            // 
            // lblAnalysis
            // 
            this.lblAnalysis.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnalysis.Appearance.Options.UseFont = true;
            this.lblAnalysis.Location = new System.Drawing.Point(5, 188);
            this.lblAnalysis.Name = "lblAnalysis";
            this.lblAnalysis.Size = new System.Drawing.Size(139, 39);
            this.lblAnalysis.TabIndex = 1;
            this.lblAnalysis.Text = "题目解析:";
            // 
            // lblAnswer
            // 
            this.lblAnswer.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer.Appearance.Options.UseFont = true;
            this.lblAnswer.Location = new System.Drawing.Point(54, 46);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(75, 39);
            this.lblAnswer.TabIndex = 0;
            this.lblAnswer.Text = "答案:";
            // 
            // ControlAnswer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "ControlAnswer";
            this.Size = new System.Drawing.Size(1043, 314);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private RichBoxEdit richBoxEdit2;
        private RichBoxEdit richEditControl1;
        private DevExpress.XtraEditors.LabelControl lblAnalysis;
        private DevExpress.XtraEditors.LabelControl lblAnswer;
    }
}
