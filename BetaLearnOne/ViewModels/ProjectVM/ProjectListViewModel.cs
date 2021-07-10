using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using BetaLearnOne.Models.ProjectModel;
using System.Collections.ObjectModel;
using BetaLearnOne.Services;
using BetaLearnOne.Views.Projects;
using BetaLearnOne.ViewModels.ProjectVM;
using System.Threading.Tasks;
using BetaLearnOne.Services.ProjectServices;

namespace BetaLearnOne.ViewModels.ProjectVM
{
   public class ProjectListViewModel : BaseViewModel
    {
        public ObservableCollection<ProjectM> Projects { get; set; }
        public Command<ProjectM> ItemClicked { get; set; }
        public Command AddProject { get; }
        public Command ReLoadItems { get; }
        public Command<ProjectM> DeleteProject { get; }




        public void OnAppearing()
        {
            IsBusy = true;
        }
            ProjectData projectData = new ProjectData();
        ProjectBaseStore baseStore = new ProjectBaseStore();
      


        public ProjectListViewModel()
        {
            Projects = new ObservableCollection<ProjectM>();
            GetProjects();
            ItemClicked = new Command<ProjectM>(OnItemClicked);
            ReLoadItems = new Command(async () => await ExecuteLoadItemsCommand());
            DeleteProject = new Command<ProjectM>(OnDelete);
        }


        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Projects.Clear();
               // var ite = await baseStore.ReturnItemsAsync();
              //  var items = baseStore.GetData();
                var data = projectData.ReturningProjects();
                ObservableCollection<ProjectM> projects = new ObservableCollection<ProjectM>();

                foreach (var item in data)
                {
                    projects.Add(item);
                }
                Projects = projects;

            }
            catch 
            {
               await Shell.Current.DisplayAlert("Error", "Could not reload items", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }



        private  void GetProjects()
        {
            ObservableCollection<ProjectM> projects = new ObservableCollection<ProjectM>();
           // var ite = await baseStore.ReturnItemsAsync();
         //   var items = baseStore.GetData();
            var data = projectData.ReturningProjects();
            foreach (var item in data)
            {
                projects.Add(item);
            }

           Projects = projects;

        }


        private async void OnDelete(ProjectM item)
        {
            ObservableCollection<ProjectM> projects = new ObservableCollection<ProjectM>();
            projectData.DeleteItem(item);
            var items = await baseStore.ReturnItemsAsync();
          //  var items = await projectData.GetProjects();
            foreach (var i in items)
            {
                projects.Add(i);
            }
          //  Projects = projects;
            

        }


        private async void OnItemClicked(ProjectM item)
        {
            if (item == null)
                return;

           await Shell.Current.GoToAsync($"{nameof(ProjectItemPage)}?{nameof(ProjectItemViewModel.ItemId)}={item.Id}");

        }









    }
}
