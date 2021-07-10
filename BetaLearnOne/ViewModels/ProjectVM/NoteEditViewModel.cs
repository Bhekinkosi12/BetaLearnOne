using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using BetaLearnOne.Models.ProjectModel;

using BetaLearnOne.Services;

namespace BetaLearnOne.ViewModels.ProjectVM
{
    [QueryProperty(nameof(ID), nameof(ID))]
    public class NoteEditViewModel : BaseViewModel
    {
        private string id;
        private string description;
        private string hint;
        
        ProjectData datastore = new ProjectData();


        public Command Save { get; }


        public NoteEditViewModel()
        {
            Save = new Command(Onsave);
        }



        private int ProjectId;
        public string ID
        {
            get => id;
            set
            {
                SetProperty(ref id, value);
                accessdata(value);
                OnPropertyChanged(nameof(ID));
            }
            
        }

        public string Description
        {
            get => description;
            set
            {
                SetProperty(ref description, value);
                OnPropertyChanged(nameof(Description));
            }
        }
        public string Hint
        {
            get => hint;
            set
            {
                SetProperty(ref hint, value);
                OnPropertyChanged(nameof(Hint));
            }
        }








        public void SettingProjectID(int id)
        {
            ProjectId = id;
        }

        private async void accessdata(string id)
        {
            try
            {

            var items = datastore.GetNote(ProjectId, Int32.Parse(id));
                Description = items.Description;
                Hint = items.Hint;

            }
            catch
            {
                await Shell.Current.DisplayAlert("Error", "ProjectID not set", "OK");
            }


            



        }

      async void Onsave()
        {
            var item = new ProjectDataM()
            {
                Description = Description,
                Hint = Hint,
                ID = Int32.Parse(ID)


            };


            datastore.UpdateNote(ProjectId, item.ID, item);

            await Shell.Current.GoToAsync("..");

        }



    }
}
