using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using BetaLearnOne.Views.Tools;
using BetaLearnOne.Models;
using BetaLearnOne.Services;
using BetaLearnOne.Views.Profile;
using System.Collections.ObjectModel;

namespace BetaLearnOne.ViewModels
{
    [QueryProperty(nameof(ItemType), nameof(ItemType))]
    public class LearnViewModel : BaseViewModel
    {
      
        private string itemID;
        private ObservableCollection<Learn> learningTab;
        LearnDataStore learnData = new LearnDataStore();
        private int position;
        private int progress;
        private int count = 0;
        private int numberOfItems;


        public Command Calculator { get; }
        public Command NextBTN { get; }
        public Command Tools { get; }
        public Command Profile { get; }




        public string ItemType
        {
            get => itemID;
            set
            {
                SetProperty(ref itemID, value);
                UsingData(value);
                OnPropertyChanged(nameof(ItemType));


            }
        }


        public int Progress
        {
            get => progress;
            set
            {
                SetProperty(ref progress, value);
                OnPropertyChanged(nameof(Progress));
            }
        }

        public int Position
        {
            get => position;
            set
            {
                SetProperty(ref position, value);
                OnPropertyChanged(nameof(Position));
            }
        }

        void OnNext()
        {
            int current = Position;
            current += 1;
            Position = current;
            Progress = ConvertingToPercent(Position,count);
          
            





        }


        public ObservableCollection<Learn>  LearningTab
        {
            get => learningTab;
            set
            {
                SetProperty(ref learningTab, value);
                OnPropertyChanged(nameof(LearningTab));
            }
        }

        private int ConvertingToPercent(int current,int lenght)
        {
            if(current <= 0 || lenght <= 0)
            {
                try
                {

                      double a =  ((current + 1) / (lenght )) * 100;
                    int b = Int32.Parse(Math.Round(a).ToString());

                    return b;

                }
                catch
                {
                   double a =  ((current + 1) / (lenght + 1)) * 100;
                    int b = Int32.Parse(Math.Round(a).ToString());
                    return b;
                }

            }



            else 
            {

                double a = (current / lenght) * 100;
                int b = Int32.Parse(Math.Round(a).ToString());
                return b;

            }

        }

        public void GetItem(Topic item)
        {
            if (item == null)
                return;
            ObservableCollection<Learn> collect = new ObservableCollection<Learn>();

            foreach(var i in item.TopicData)
            {
                collect.Add(i);
                count += 1;
            }
            LearningTab = collect;

            Progress = ConvertingToPercent(1, count);
           

        //   Progress = Int32.Parse(Math.Round(ConvertingToPercent(item.TopicProgress, item.TopicData.Count)).ToString());

            
          //  Progress = item.TopicProgress;

        }


        private void UsingData(string type)
        {
            ObservableCollection<Learn> collect = new ObservableCollection<Learn>();
            foreach (var ip in learnData.GetListByType(type))
            {
                collect.Add(ip);
            }
            
            LearningTab = collect;

        }

        public LearnViewModel()
        {
            Tools = new Command(GetTools);
            NextBTN = new Command(OnNext);
            Calculator = new Command(GetCalculator);
            Profile = new Command(GetProfile);





        }

       async void GetCalculator()
        {
            await Shell.Current.GoToAsync($"{nameof(CalculatorPage)}");
        }
        async void GetProfile()
        {
            try
            {


                await Shell.Current.GoToAsync("../..");    
            await Shell.Current.GoToAsync($"{nameof(ProfilePage)}");

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

         void GetTools()
        {
          //  await Shell.Current.GoToAsync(nameof(ToolOptionsPage));

        }


    }
}
