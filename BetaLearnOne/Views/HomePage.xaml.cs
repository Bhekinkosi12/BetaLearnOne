using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BetaLearnOne.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
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
    }
}