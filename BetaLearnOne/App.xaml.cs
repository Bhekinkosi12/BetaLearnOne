using BetaLearnOne.Services;
using BetaLearnOne.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BetaLearnOne.Services.AuthenticationServices;

namespace BetaLearnOne
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<UserData>();
            DependencyService.Register<BaseUserStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
