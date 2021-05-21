using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BetaLearnOne.ViewModels.AuthenticationVM;


namespace BetaLearnOne.Views.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginStudent : ContentPage
    {
        public LoginStudent()
        {
            InitializeComponent();
        }
        StudentViewModel studentViewModel = new StudentViewModel();


        private async void ForgotPassword_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SigninStudent());
        }

        private async void login_Clicked(object sender, EventArgs e)
        {
            if(studentViewModel.Verified() == true)
            {
                await Navigation.PushAsync(new AppShell());
            }
            else
            {
                await DisplayAlert("Error", "Please check your inputs", "OK");
            }
        }
    }
}