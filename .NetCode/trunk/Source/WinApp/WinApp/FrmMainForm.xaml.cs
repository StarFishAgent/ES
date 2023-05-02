using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace WinApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmMainForm : ContentPage
    {
        public FrmMainForm()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var expectedFormat = ZXing.BarcodeFormat.QR_CODE;
            var opts = new ZXing.Mobile.MobileBarcodeScanningOptions
            {
                PossibleFormats = new List<ZXing.BarcodeFormat>
                { expectedFormat}
            };
            var scanPage = new ZXingScannerPage(opts);
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                    await DisplayAlert("scanned Barcode", result.Text, "OK");
                });
            };
            await Navigation.PushModalAsync(scanPage);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }

        private async void Button_Clicked2(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;

            var ResultJson = webClient.UploadString("http://192.168.100.12:18801/webapi/EQ", JsonConvert.SerializeObject(new { strSql = "select * from UserInfo" }));
            await DisplayAlert("测试API", "调用成功", "Ok");
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            {
                var bs = new MobileBarcodeScanner();
                var barcode_task = await bs.Scan();
                var barcode = barcode_task.Text;
                if (barcode != null&& barcode !="")
                {
                    var dt = SqlHelper.EQ($@"select * from BarcodeInfo where barcode='{barcode}'");
                    if (dt != null && dt.Rows.Count == 0)
                    {
                        SqlHelper.EQ($@"insert into BarcodeInfo(barcode,user_guid)values('{barcode}','{App.user_guid}')");
                    }
                    await DisplayAlert("Scanned Barcode", "登录成功！", "OK");
                }
            }
        }
    }
}