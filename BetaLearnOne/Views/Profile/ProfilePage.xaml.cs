using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BetaLearnOne.Views.Popups;


namespace BetaLearnOne.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void EditClicked(object sender, EventArgs e)
        {
            
            //  Shell.Current.ShowPopup(new ProfileEdit());
            Shell.Current.ShowPopup(new ProfileEdit());

        }
        }
}