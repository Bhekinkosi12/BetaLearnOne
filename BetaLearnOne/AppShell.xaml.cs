using BetaLearnOne.ViewModels;
using BetaLearnOne.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using BetaLearnOne.Views.Tools;
using BetaLearnOne.Views.Authentication;
using BetaLearnOne.Views.LearnView;
using BetaLearnOne.Views.Profile;
using BetaLearnOne.Views.Popups;

namespace BetaLearnOne
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(CalculatorPage), typeof(CalculatorPage));
            Routing.RegisterRoute(nameof(LoginStaff), typeof(LoginStaff));
            Routing.RegisterRoute(nameof(LoginStudent), typeof(LoginStudent));
            Routing.RegisterRoute(nameof(SigninStudent), typeof(SigninStudent));
            Routing.RegisterRoute(nameof(LearnPage), typeof(LearnPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(ToolPopup), typeof(ToolPopup));
            Routing.RegisterRoute(nameof(ProfileEdit), typeof(ProfileEdit));
        }

    }
}
