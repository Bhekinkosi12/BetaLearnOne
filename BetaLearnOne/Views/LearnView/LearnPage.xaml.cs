using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BetaLearnOne.Views.Popups;

namespace BetaLearnOne.Views.LearnView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LearnPage : ContentPage
    {
        public LearnPage()
        {
            InitializeComponent();
        }

        private  void Tools_Clicked(object sender, EventArgs e)
        {
            // SlideFrame.IsVisible = true;
            Shell.Current.ShowPopup(new ToolPopup());
           
        }

        private void PageFrame_Tapped(object sender, EventArgs e)
        {
            SlideFrame.IsVisible = false;
        }

        private void BTNProfile_Clicked(object sender, EventArgs e)
        {
            SlideFrame.IsVisible = false;
        }

        private void BTNCalculator_Clicked(object sender, EventArgs e)
        {
            SlideFrame.IsVisible = false;
        }
    }
}