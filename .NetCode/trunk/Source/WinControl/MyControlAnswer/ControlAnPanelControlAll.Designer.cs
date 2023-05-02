namespace WinControl {
    partial class AnPanelControlAll {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.AnswerPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // AnswerPanel
            // 
            this.AnswerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnswerPanel.Location = new System.Drawing.Point(0, 0);
            this.AnswerPanel.Name = "AnswerPanel";
            this.AnswerPanel.Size = new System.Drawing.Size(1137, 120);
            this.AnswerPanel.TabIndex = 0;
            this.AnswerPanel.Enter += new System.EventHandler(this.AnswerPanel_Enter);
            // 
            // AnPanelControlAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AnswerPanel);
            this.Name = "AnPanelControlAll";
            this.Size = new System.Drawing.Size(1137, 120);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel AnswerPanel;
    }
}
