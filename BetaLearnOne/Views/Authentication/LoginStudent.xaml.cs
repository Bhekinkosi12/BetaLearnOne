using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BetaLearnOne.ViewModels.AuthenticationVM;
using Xamarin.CommunityToolkit.Extensions;
using BetaLearnOne.Views.Popups.Logging;

namespace BetaLearnOne.Views.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginStudent : ContentPage
    {
        public LoginStudent()
        {
            InitializeComponent();
        }
       


        private  void ForgotPassword_Clicked(object sender, EventArgs e)
        {
            Shell.Current.ShowPopup(new ForgotPasswordPage());

        //    await Navigation.PushAsync(new SigninStudent());
        }

        private void login_Clicked(object sender, EventArgs e)
        {
         
        }
    }
}