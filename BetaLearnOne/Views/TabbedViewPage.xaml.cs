using Syncfusion.XForms.TabView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetaLearnOne.Views.LearnView;
using BetaLearnOne.Views.Projects;
using BetaLearnOne.Views.Tools;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BetaLearnOne.Views;
using Syncfusion.XForms.PopupLayout;
using BetaLearnOne.Views.Popups;

namespace BetaLearnOne.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedViewPage : ContentPage
    {
      
        public TabbedViewPage()
        {
            InitializeComponent();
           
            
          
        }

        private  void SfTabView_CenterButtonTapped(object sender, EventArgs e)
        {
            // await Shell.Current.GoToAsync("HomePopup");
            Shell.Current.ShowPopup(new MenuPopup());
        }
    }
}