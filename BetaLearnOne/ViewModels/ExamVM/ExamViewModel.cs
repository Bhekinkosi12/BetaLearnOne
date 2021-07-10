using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BetaLearnOne.Services.ExamDataStore;
using System.Reflection;
using Xamarin.Forms;

namespace BetaLearnOne.ViewModels.ExamVM
{
    [QueryProperty(nameof(ItemID), nameof(ItemID))]
    public class ExamViewModel : BaseViewModel
    {
        private string itemId;
        private string position;
        private Stream question;
        private Stream answer;

        ExamData data = new ExamData();
         
        public string ItemID
        {
            get => itemId;
            set
            {
                SetProperty(ref itemId, value);
                // LoadItem(value);
                loadFromDicionary(value);


                OnPropertyChanged(nameof(ItemID));
            }
        }


      

        public Stream Question
        {
            get => question;
            set
            {
                SetProperty(ref question, value);
                OnPropertyChanged(nameof(Question));
            }

        }
        public Stream Answer
        {
            get => answer;
            set
            {
                SetProperty(ref answer, value);
                OnPropertyChanged(nameof(Answer));
            }
        }





       async void LoadItem(string id)
        {
            try
            {

           var item = data.GetItemById(id);

            Question = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(item.PaperPath);
            Answer = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(item.MemoPath);
            }
             catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }




        }

     

       async void loadFromDicionary(string id)
        {
            try
            {

            var item = data.ItemFromDictionary(id);
            Question = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(item[0]);
            Answer = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(item[1]);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }


        }

       



    }
}
