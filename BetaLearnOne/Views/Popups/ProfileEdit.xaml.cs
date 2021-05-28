using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BetaLearnOne.ViewModels.ProfileVM;

namespace BetaLearnOne.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileEdit : Popup
    {
        ProfileViewModel profile = new ProfileViewModel();
        public ProfileEdit()
        {
            InitializeComponent();
        }

        private void Popup_Dismissed(object sender, PopupDismissedEventArgs e)
        {
             
        }

       
    }
}