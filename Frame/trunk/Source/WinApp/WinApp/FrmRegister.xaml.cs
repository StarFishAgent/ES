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
    public partial class FrmRegister : ContentPage
    {
        public FrmRegister()
        {
            InitializeComponent();
            
        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            var user_no = txtUserNo.Text.Trim();
            var user_pwd = txtUserPwd.Text.Trim();
            var user_name = txtUserName.Text.Trim();
            var user_repwd = txtRePwd.Text.Trim();
            if (user_no == "")
            {
                DisplayAlert("Tips", "请输入用户名", "OK");
                return;
            }
            if (user_pwd == "")
            {
                DisplayAlert("Tips", "请输入密码", "OK");
                return;
            }
            if (user_pwd != user_repwd)
            {
                DisplayAlert("Tips", "两次密码输入不一致", "OK");
                return;
            }
            if (user_name == "")
            {
                DisplayAlert("Tips", "请输入用户姓名", "OK");
                return;
            }

            var dt = SqlHelper.EQ($@"select * from UserInfo where user_no='{user_no}'");
            if (dt != null && dt.Rows.Count > 0)
            {
                DisplayAlert("Tips", "用户名已存在", "OK");
                return;
            }
            else
            {
                SqlHelper.ENQ($@"insert into UserInfo(user_no,user_pwd,user_name)values('{user_no}','{user_pwd}','{user_name}')");
                DisplayAlert("Tips", "注册成功", "OK");
                {
                    var user_dt = SqlHelper.EQ($@"select * from UserInfo where user_no='{user_no}'");
                    var dr = user_dt.Rows[0];
                    App.user_guid = Convert.ToString(dr["guid"]);
                }
                Navigation.PushModalAsync(new FrmMainForm());


            }
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}