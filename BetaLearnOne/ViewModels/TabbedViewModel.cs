using System;
using System.Collections.Generic;
using System.Text;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;
using BetaLearnOne.Views.LearnView;
using BetaLearnOne.Views.Projects;
using BetaLearnOne.Views.Tools;
using Rg.Plugins.Popup.Services;
using Xamarin.CommunityToolkit.Extensions;
using BetaLearnOne.Views;
using BetaLearnOne.Views.Profile;
using BetaLearnOne.Views.Popups;

namespace BetaLearnOne.ViewModels
{
   public class TabbedViewModel : BaseViewModel
    {
        private bool isOpen = false;


        public TabItemCollection sfTabItems { get; set; }
       
        public Command Open { get; set; }

        public TabbedViewModel()
        {
            sfTabItems = new TabItemCollection();
           
            addtabs();

            Open = new Command(OnOpen);

            
            
        }




        void addtabs()
        {




            SfTabItem item = new SfTabItem()
            {
                SelectionColor = Color.Blue,
                Content = new ItemsPage().Content,
                ImageSource = "UiJournal.png",
                Title = "Learn",
                FlowDirection = FlowDirection.RightToLeft,
                
                TitleFontColor = Color.FromHex("#101010"),
                TitleFontSize = 20,
                
               


            };
            SfTabItem item12 = new SfTabItem()
            {
                SelectionColor = Color.Blue,
                Content = new MainProjectPage().Content,
                ImageSource = "UiSelfies.png",
                Title = "Project",
                FlowDirection = FlowDirection.LeftToRight,
                TitleFontSize = 20,
                TitleFontColor = Color.FromHex("#101010")
            };

        

            sfTabItems.Add(item);
            sfTabItems.Add(item12);
           


        }



       async void OnOpen()
        {
            try
            {
                var page = new HomePopup();
                await PopupNavigation.Instance.PushAsync(page);
          //  Shell.Current.ShowPopup(new MenuPopup());

            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }


        }

    }
}
