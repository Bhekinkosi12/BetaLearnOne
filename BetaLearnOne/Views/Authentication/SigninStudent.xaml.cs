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
    public partial class SigninStudent : ContentPage
    {
        public SigninStudent()
        {
            InitializeComponent();
        }
        SignInViewModel signinViewModel = new SignInViewModel();

        private void BarLevel_ValueChanged(object sender, Syncfusion.XForms.ProgressBar.ProgressValueEventArgs e)
        {
            if(BarLevel.Progress >= 50 && BarLevel.Progress <= 70)
            {
                BarLevel.ProgressColor = Color.Yellow;
            }
            else if(BarLevel.Progress > 70)
            {
                BarLevel.ProgressColor = Color.Green;
            }
        }

        private async void submit_Clicked(object sender, EventArgs e)
        {
            if(signinViewModel.Verified() == true)
            {
                await Navigation.PushAsync(new AppShell());
            }
            else
            {
                await DisplayAlert("Incomplete form", "Please make sure everything is entered", "OK");
            }

        }
    }
}