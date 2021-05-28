using BetaLearnOne.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using BetaLearnOne.Views.Authentication;

namespace BetaLearnOne.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public Command LoginAsStudent { get; }

        public Command LoginAsStaff { get; }

        public Command SignIn { get; }


        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);

            LoginAsStaff = new Command(OnLoginAsStaff);
            LoginAsStudent = new Command(OnLoginAsStudent);
            SignIn = new Command(OnSignIn);

        }

        private async void OnSignIn()
        {
            await Shell.Current.GoToAsync(nameof(SigninStudent));
            
        }
        

        private async void OnLoginAsStudent()
        {

            await Shell.Current.GoToAsync(nameof(LoginStudent));

        }
        private async void OnLoginAsStaff()
        {

            await Shell.Current.GoToAsync(nameof(LoginStaff));

        }


        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
