
namespace WinControl
{
    partial class RePanelControlAll
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
            this.StarFishPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // StarFishPanel
            // 
            this.StarFishPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StarFishPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.StarFishPanel.Location = new System.Drawing.Point(0, 0);
            this.StarFishPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StarFishPanel.Name = "StarFishPanel";
            this.StarFishPanel.Size = new System.Drawing.Size(1137, 494);
            this.StarFishPanel.TabIndex = 0;
            this.StarFishPanel.WrapContents = false;
            // 
            // RePanelControlAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StarFishPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RePanelControlAll";
            this.Size = new System.Drawing.Size(1137, 494);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel StarFishPanel;
    }
}
