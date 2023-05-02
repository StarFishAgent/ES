using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WinApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmLogin : ContentPage
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //var user_no = txtUserNo.Text.Trim();
            //var user_pwd = txtUserPwd.Text.Trim();
            //if (user_no == "" || user_no == null)
            //{
            //    await DisplayAlert("Tips", "请输入用户名", "OK");
            //    return;
            //}
            //if (user_pwd == "" || user_pwd == null)
            //{
            //    await DisplayAlert("Tips", "请输入密码", "OK");
            //    return;
            //}
            var dt = SqlHelper.EQ($@"select * from UserInfo where user_no='{1}' and user_pwd ='{1}'");
            if (dt != null && dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
                var user_guid = Convert.ToString(dr["guid"]);
                App.user_guid = user_guid;
                await Navigation.PushModalAsync(new FrmMainForm());
            }
            else
            {
                await DisplayAlert("灾难性错误", "用户名或密码错误", "OK");
                return;
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new FrmRegister());
        }
    }
}