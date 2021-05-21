using BetaLearnOne.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BetaLearnOne.Views.Authentication;

namespace BetaLearnOne.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private void students_Tapped(object sender, EventArgs e)
        {
          //  await Navigation.PushAsync(new LoginStudent());
        }

        private  void Staff_Tapped(object sender, EventArgs e)
        {
         //   await Navigation.PushAsync(new LoginStaff());
        }
    }
}