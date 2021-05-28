using System;
using System.Collections.Generic;
using System.Text;
using BetaLearnOne.Services;
using Syncfusion.SfCalendar.XForms;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using BetaLearnOne.Views.Popups.CalendarPop;

namespace BetaLearnOne.ViewModels.CalenderVM
{
   public class CalendarViewModel : BaseViewModel
    {



        public CalendarViewModel()
        {
            GetData();
            Hold = new Command(OnHold);
        }



        private CalendarEventCollection events;
        private DateTime newDate;
        private DateTime selectedDate;

        CalendarDataStore store = new CalendarDataStore();
        public Command Hold { get; }
        






        public CalendarEventCollection Events
        {
            get => events;
            set
            {
                SetProperty(ref events, value);
                OnPropertyChanged(nameof(Events));
            }
        }



        public DateTime SelectedDate
        {
            get => selectedDate;
            set
            {
                SetProperty(ref selectedDate, value);
                OnPropertyChanged(nameof(SelectedDate));
            }
        }




        public DateTime NewDate

        {
            get => newDate;
            set
            {
                SetProperty(ref newDate, value);
                OnPropertyChanged(nameof(NewDate));
                    
            }


        }




        void GetData()
        {

            Events = store.AccessEvents();

        }
       async void OnHold()
        {
            try
            {

            Shell.Current.ShowPopup(new SetDatePopup());
            } catch(Exception ex)
            {

                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            

        }



    }
}
