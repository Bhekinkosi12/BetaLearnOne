using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BetaLearnOne.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPopup : Popup
    {
        public MenuPopup()
        {
            InitializeComponent();
        }

        private async void back_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("../..");
        }
    }
}