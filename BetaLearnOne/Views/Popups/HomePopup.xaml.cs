using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
    
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BetaLearnOne.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePopup : PopupPage
    {
        public HomePopup()
        {
            InitializeComponent();
        }

        private async void calculator_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("CalculatorPage");
        }

        private async void Note_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("MainProjectPage");
        }

        private async void calendar_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("CalendarPage");
        }

        private async void back_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        protected override bool OnBackButtonPressed()
        {
            //   return base.OnBackButtonPressed();
            return false;
        }

        private async void home_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
            await Shell.Current.GoToAsync("ProfilePage");
        }
    }
}