using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BetaLearnOne.Services.ExamDataStore;
using System.Reflection;

namespace BetaLearnOne.ViewModels.ExamVM
{
   public class ExamViewModel : BaseViewModel
    {
        private string itemId;
        private Stream question;
        private Stream answer;

        ExamData data = new ExamData();

        public string ItemId
        {
            get => itemId;
            set
            {
                SetProperty(ref itemId, value);
                LoadItem(value);
                OnPropertyChanged(nameof(ItemId));
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





        void LoadItem(string id)
        {

           var item = data.ItemById(id);

            Question = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(item.PaperPath);
            Answer = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(item.MemoPath);





        }



    }
}
