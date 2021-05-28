using System;
using System.Collections.Generic;
using System.Text;
using BetaLearnOne.Models.ProjectModel;
using BetaLearnOne.Services;
using Xamarin.Forms;
using BetaLearnOne.Views.Tools;

namespace BetaLearnOne.ViewModels.ProjectVM
{
    [QueryProperty(nameof(ID),nameof(ID))]
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
         
        ProjectData projectData = new ProjectData();
        public Command Calendar { get; }

 
        public ProjectItemViewModel()
        {
            Calendar = new Command(OnCalendar);
        }

        public string ID
        {
            get => id;
            set
            {
                SetProperty(ref id, value);
                GetItems(value);
                OnPropertyChanged(nameof(ID));
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
                var item = projectData.GetItemByID(id);
                
                Subject = item.Subject;
                ProjectName = item.ProjectName;
                ProjectDescription = item.ProjectDescription;
                StartDate = item.StartDate;
                DueDate = item.DueDate;
                ImagePreview = item.ImagePreview;
                ProjectColor = item.ProjectColor;
                IsAdmin = false;

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



    }
}
