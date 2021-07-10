using System;
using System.Collections.Generic;
using System.Text;
using BetaLearnOne.Models.ProjectModel;
using BetaLearnOne.Services;
using Xamarin.Forms;
using BetaLearnOne.Views.Tools;
using BetaLearnOne.Services.ProjectServices;
using System.Collections.ObjectModel;
using BetaLearnOne.Views.Projects;

namespace BetaLearnOne.ViewModels.ProjectVM
{
    [QueryProperty(nameof(ItemId),nameof(ItemId))]
    public class ProjectItemViewModel : BaseViewModel
    {
        private Subjects subject;
        private string projectName;
        private string projectDecription;
        private DateTime startDate;
        private DateTime dueDate;
        private string imagePreview;
        private string projectColor;
        private string id;
        private string itemId;
        private string itemNote;
        private string previous;
        private ProjectDataM selectedItem;

        private ObservableCollection<ProjectDataM> notes;
        ProjectBaseStore BaseStore = new ProjectBaseStore();
       ProjectData projectData = new ProjectData();
        NoteEditViewModel note = new NoteEditViewModel();
        public Command Calendar { get; }
        public Command Save { get; }
        public Command Cancel { get; }
        public Command Edit { get; }
        public Command<ProjectDataM> NoteClicked { get; set; }

 
        public ProjectItemViewModel()
        {
            Calendar = new Command(OnCalendar);
            NoteClicked = new Command<ProjectDataM>(OnNoteClick);
            Save = new Command(OnSave);
            Cancel = new Command(OnDelete);
            Edit = new Command(OnEdit);
        }

        
    
        public ProjectDataM SelectedItem
        {
            get => selectedItem;
            set
            {
                SetProperty(ref selectedItem, value);
                OnNoteClick(value);
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public string ItemNote
        {
            get => itemNote;
            set
            {
                SetProperty(ref itemNote, value);
                OnPropertyChanged(nameof(ItemNote));
            }
        }

        public string ItemId
        {
            get => itemId;
            set
            {
                SetProperty(ref itemId, value);
                GetItems(value);
                OnPropertyChanged(nameof(ItemId));
            }
        }

        public string ID
        {
            get => id;
            set
            {
                SetProperty(ref id, value);
               
                OnPropertyChanged(nameof(ID));
            }
        }

        public ObservableCollection<ProjectDataM> Notes
        {
            get => notes;
            set
            {
                SetProperty(ref notes, value);
                OnPropertyChanged(nameof(Notes));
            }
        }

        public Subjects Subject
        {
            get => subject;
            set
            {
                SetProperty(ref subject, value);
                OnPropertyChanged(nameof(Subject));
            }
        }
       public string ProjectName
        {
            get => projectName;
            set
            {
                SetProperty(ref projectName, value);
                OnPropertyChanged(nameof(ProjectName));

            }
        }
        public string ProjectDescription
        {
            get => projectDecription;
            set
            {
                SetProperty(ref projectDecription, value);
                OnPropertyChanged(nameof(ProjectDescription));
            }
        }
        public DateTime StartDate
        {
            get => startDate;
            set
            {
                SetProperty(ref startDate, value);
                OnPropertyChanged(nameof(StartDate));
            }
        }
        public DateTime DueDate
        {
            get => dueDate;
            set
            {
                SetProperty(ref dueDate, value);
                OnPropertyChanged(nameof(DueDate));
            }
        }
        public string ImagePreview
        {
            get => imagePreview;
            set
            {
                SetProperty(ref imagePreview, value);
                OnPropertyChanged(nameof(ImagePreview));
            }
        }
        
        public string ProjectColor
        {
            get => projectColor;
            set
            {
                SetProperty(ref projectColor, value);
                OnPropertyChanged(nameof(ProjectColor));
            }
        }
        






       async private void GetItems(string id)
        {
            try
            {

                ObservableCollection<ProjectDataM> list = new ObservableCollection<ProjectDataM>();
                var item = projectData.ReturningItemById(Int32.Parse(id));
              //  var item = await BaseStore.GetItemByIdAsync(Int32.Parse(id));
                
                Subject = item.Subject;
                ProjectName = item.ProjectName;
                ProjectDescription = item.ProjectDescription;
                StartDate = item.StartDate;
                DueDate = item.DueDate;
                ImagePreview = item.ImagePreview;
                ProjectColor = item.ProjectColor;
                ItemNote = item.Notes;
                IsAdmin = false;

                foreach(var i in projectData.GetNoteData(item.Id))
                {
                    list.Add(i);
                    
                }
                Notes = list;
                

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
              ///  await Shell.Current.GoToAsync("..");
            }



        }
      
       

       async void OnCalendar()
        {

            await Shell.Current.GoToAsync(nameof(CalenderPage));
        }


        void OnSave()
        {
            projectData.UpdatingItemNote(ItemNote, Int32.Parse(ItemId));
            projectData.UpdateItemDescription(ProjectDescription, Int32.Parse(ItemId));
        }
        void OnEdit()
        {
            previous = ItemNote;
        }
        void OnDelete()
        {
            ItemNote = previous;
        }


       private async void OnNoteClick(ProjectDataM item)
        {
            try
            {

           
            note.SettingProjectID(Int32.Parse(ItemId));
              //  NoteEditViewModel notes = new NoteEditViewModel();
              //  notes.ID = item.ID.ToString();
               // await Shell.Current.GoToAsync(nameof(NoteEditPage));
           await Shell.Current.GoToAsync($"{nameof(NoteEditPage)}?{nameof(NoteEditViewModel.ID)}={item.ID}");
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }


        }



    }
}
