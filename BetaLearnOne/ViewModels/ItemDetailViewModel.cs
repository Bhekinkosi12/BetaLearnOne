using BetaLearnOne.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using BetaLearnOne.Views.LearnView;
using BetaLearnOne.Views.Tools;
using BetaLearnOne.Services;


namespace BetaLearnOne.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string proName;
        private string description;
        private string subImage;
        private string intro;
        private Topic currentItem;
        private string backgroundImage;
        private ObservableCollection<Topic> listTopics;
        private ObservableCollection<Learn> learnList;
        private List<Learn> learningData;
        LearnViewModel learnViewModel = new LearnViewModel();
        TopicsDataStore topicsDataStore = new TopicsDataStore();

        private List<Topic> listTopicsHO;
        public Command Click { get; }
        public Command Tools { get; }



        public ItemDetailViewModel()
        {
            Click = new Command(OnClick);
            Tools = new Command(GetTools);
        }
        



        public string BackgroundImage
        {
            get => backgroundImage;
            set
            {
                SetProperty(ref backgroundImage, value);
                OnPropertyChanged(nameof(BackgroundImage));
            }
        }

        public string Intro
        {
            get => intro;
            set
            {
                SetProperty(ref intro, value);
                OnPropertyChanged(nameof(Intro));
            }
        }
        public string ProName
        {
            get => proName;
            set
            {
                SetProperty(ref proName, value);
                OnPropertyChanged(nameof(ProName));
            }
        }

        public Topic CurrentItem
        {
            get => currentItem;
            set
            {
                SetProperty(ref currentItem, value);
                OnSelecetedItem(value);
                OnPropertyChanged(nameof(CurrentItem));
            }
        }
        public string Id { get; set; }


     
        public List<Topic> ListTopicsHO
        {
            get => listTopicsHO;
            set
            {
                SetProperty(ref listTopicsHO, value);
                OnPropertyChanged(nameof(ListTopicsHO));
            }
        }

        public ObservableCollection<Topic> ListTopics
        {
            get => listTopics;
            set
            {
                SetProperty(ref listTopics, value);
                OnPropertyChanged(nameof(ListTopics));
            }
        }
        public string SubImage
        {
            get => subImage;
            set
            {
                SetProperty(ref subImage, value);
                OnPropertyChanged(nameof(SubImage));
            }
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }



        public List<Learn> LearningData
        {
            get => learningData;
            set
            {
                SetProperty(ref learningData, value);
                OnPropertyChanged(nameof(LearningData));
            }
        }


        public ObservableCollection<Learn> LearnList
        {
            get => learnList;
            set
            {
                SetProperty(ref learnList, value);
                OnPropertyChanged(nameof(LearnList));
            }
        }
        

        public async void LoadItemId(string itemId)
        {
            try
            {
                ObservableCollection<Topic> collect = new ObservableCollection<Topic>();
                

                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
                ListTopicsHO = item.List;
                SubImage = item.SubImage;
                BackgroundImage = item.SubBackground;
                

              

                foreach(var i in item.List)
                {
                    collect.Add(i);

                    
                }
                ListTopics = collect;
               


            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        void OnSelecetedItem(Topic item)
        {


            var itemm = topicsDataStore.GetIdByItem(item);



        }
       
      

        async void OnClick()
        {

            int count = 0;

            try
            {

                ObservableCollection<Learn> collect = new ObservableCollection<Learn>();
                foreach (var i in CurrentItem.TopicData)
                {
                    collect.Add(i);
                    count += 1;
                }
                
                LearnList = collect;
                LearningData = CurrentItem.TopicData;


             

                



               // await Shell.Current.GoToAsync($"{nameof(LearnPage)}");
                
                 await Shell.Current.GoToAsync($"{nameof(LearnPage)}?{nameof(LearnViewModel.ItemType)}={CurrentItem.TopicDataType}");
            }
            catch(Exception ex)
            {
              await  Shell.Current.DisplayAlert("Erorr", ex.Message, "OK");
            }

        }







        async void GetTools()
        {
            await Shell.Current.GoToAsync(nameof(CalculatorPage));

        }


    }
}
