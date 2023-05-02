
namespace WinClient
{
    /// <summary>
    /// 二维码窗体
    /// </summary>
    partial class FrmQRCode
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
            DevExpress.XtraPrinting.BarCode.QRCodeGenerator qrCodeGenerator2 = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
            this.barCodeControl = new DevExpress.XtraEditors.BarCodeControl();
            this.timerQR = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // barCodeControl
            // 
            this.barCodeControl.AutoModule = true;
            this.barCodeControl.Location = new System.Drawing.Point(310, 140);
            this.barCodeControl.Name = "barCodeControl";
            this.barCodeControl.Padding = new System.Windows.Forms.Padding(10, 2, 10, 0);
            this.barCodeControl.ShowText = false;
            this.barCodeControl.Size = new System.Drawing.Size(140, 132);
            qrCodeGenerator2.CompactionMode = DevExpress.XtraPrinting.BarCode.QRCodeCompactionMode.Byte;
            qrCodeGenerator2.ErrorCorrectionLevel = DevExpress.XtraPrinting.BarCode.QRCodeErrorCorrectionLevel.M;
            qrCodeGenerator2.Version = DevExpress.XtraPrinting.BarCode.QRCodeVersion.Version1;
            this.barCodeControl.Symbology = qrCodeGenerator2;
            this.barCodeControl.TabIndex = 0;
            this.barCodeControl.Click += new System.EventHandler(this.barCodeControl_Click);
            // 
            // timerQR
            // 
            this.timerQR.Interval = 500;
            this.timerQR.Tick += new System.EventHandler(this.timerQR_Tick);
            // 
            // FrmQRCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.barCodeControl);
            this.Name = "FrmQRCode";
            this.Text = "二维码";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmQRCode_FormClosing);
            this.Load += new System.EventHandler(this.FrmQRCode_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.BarCodeControl barCodeControl;
        private System.Windows.Forms.Timer timerQR;
    }
}