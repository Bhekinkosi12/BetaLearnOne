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
using BetaLearnOne.Models.ExamModel;
using BetaLearnOne.Views.ExamView;
using BetaLearnOne.ViewModels.ExamVM;


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
        private Paper currentItem;
        private string backgroundImage;
        private ObservableCollection<Paper> listTopics;
        
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
        



    

        public string Intro
        {
            get => intro;
            set
            {
                SetProperty(ref intro, value);
                OnPropertyChanged(nameof(Intro));
            }
        }
   

        public Paper CurrentItem
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


     
       

        public ObservableCollection<Paper> ListTopics
        {
            get => listTopics;
            set
            {
                SetProperty(ref listTopics, value);
                OnPropertyChanged(nameof(ListTopics));
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


     
        

        public async void LoadItemId(string itemId)
        {
            try
            {
                ObservableCollection<Paper> collect = new ObservableCollection<Paper>();
                
                 
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                
            

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

        void OnSelecetedItem(Paper item)
        {


          //  var itemm = topicsDataStore.GetIdByItem(item);



        }
       
      

        async void OnClick()
        {

          

            try
            {


               // await Shell.Current.GoToAsync($"{nameof(LearnPage)}");
                
                 await Shell.Current.GoToAsync($"{nameof(ExamPage)}?{nameof(ExamViewModel.ItemId)}={CurrentItem.ID}");
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
