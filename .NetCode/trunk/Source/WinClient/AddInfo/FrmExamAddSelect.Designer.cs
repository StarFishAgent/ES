
namespace WinClient
{
    /// <summary>
    /// 添加题目选项窗体
    /// </summary>
    partial class FrmExamAddSelect
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
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblTitleText = new DevExpress.XtraEditors.LabelControl();
            this.txtContent = new WinControl.MyControl.RichBoxEdit();
            this.LayoutPanelAll = new System.Windows.Forms.FlowLayoutPanel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1745, 203);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShowToolTips = false;
            this.btnSave.Size = new System.Drawing.Size(122, 40);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel2});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dockPanel2.ID = new System.Guid("c18eb6c1-241c-4dfc-93c7-7cb7904a1b58");
            this.dockPanel2.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 310);
            this.dockPanel2.Size = new System.Drawing.Size(1906, 310);
            this.dockPanel2.Text = "`";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.numericUpDown1);
            this.dockPanel2_Container.Controls.Add(this.btnSave);
            this.dockPanel2_Container.Controls.Add(this.labelControl2);
            this.dockPanel2_Container.Controls.Add(this.lblTitleText);
            this.dockPanel2_Container.Controls.Add(this.txtContent);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 38);
            this.dockPanel2_Container.Margin = new System.Windows.Forms.Padding(4);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(1898, 265);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(183, 44);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(180, 29);
            this.numericUpDown1.TabIndex = 29;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(36, 39);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(139, 39);
            this.labelControl2.TabIndex = 28;
            this.labelControl2.Text = "子题数量:";
            // 
            // lblTitleText
            // 
            this.lblTitleText.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleText.Appearance.Options.UseFont = true;
            this.lblTitleText.Location = new System.Drawing.Point(405, 39);
            this.lblTitleText.Margin = new System.Windows.Forms.Padding(4);
            this.lblTitleText.Name = "lblTitleText";
            this.lblTitleText.Size = new System.Drawing.Size(139, 39);
            this.lblTitleText.TabIndex = 3;
            this.lblTitleText.Text = "题目内容:";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(574, 18);
            this.txtContent.Margin = new System.Windows.Forms.Padding(6);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(1161, 225);
            this.txtContent.TabIndex = 2;
            // 
            // LayoutPanelAll
            // 
            this.LayoutPanelAll.AutoScroll = true;
            this.LayoutPanelAll.AutoSize = true;
            this.LayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanelAll.Location = new System.Drawing.Point(0, 310);
            this.LayoutPanelAll.Margin = new System.Windows.Forms.Padding(4);
            this.LayoutPanelAll.Name = "LayoutPanelAll";
            this.LayoutPanelAll.Size = new System.Drawing.Size(1906, 1289);
            this.LayoutPanelAll.TabIndex = 25;
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FrmExamAddSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1906, 1599);
            this.Controls.Add(this.LayoutPanelAll);
            this.Controls.Add(this.dockPanel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmExamAddSelect";
            this.Text = "添加题目选项";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmExamAddSelect_FormClosing);
            this.Load += new System.EventHandler(this.FrmAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            this.dockPanel2_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraEditors.LabelControl lblTitleText;
        private WinControl.MyControl.RichBoxEdit txtContent;
        private System.Windows.Forms.FlowLayoutPanel LayoutPanelAll;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Timer timer;
    }
}