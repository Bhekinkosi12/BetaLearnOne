using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BetaLearnOne.Views.Tools;

namespace BetaLearnOne.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToolPopup : Popup
    {
        public ToolPopup()
        {
            InitializeComponent();
        }
        
        private async void BTNCalculator_Clicked(object sender, EventArgs e)
        {
             
            await Shell.Current.GoToAsync(nameof(CalculatorPage));
            

        }

        private async void calendar_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CalenderPage));

        }
    }
}