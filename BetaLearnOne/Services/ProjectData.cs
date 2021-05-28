using System;
using System.Collections.Generic;
using System.Text;
using BetaLearnOne.Models.ProjectModel;
using BetaLearnOne.Services;
using Xamarin.Forms;
using System.Linq;

namespace BetaLearnOne.Services
{
   public class ProjectData
    {
        private List<ProjectM> ProjectItems { get; set; }


        public ProjectData()
        {
            ProjectDataAcess();
        }


        private void ProjectDataAcess()
        {

            ProjectItems = new List<ProjectM>()
            {
                new ProjectM
                {
                    ID = Guid.NewGuid().ToString(),
                    Subject = Subjects.Mathametics,
                    ProjectName = "Example",
                    ProjectDescription = "A brief Explaination of how a projects item is previewed",
                    ImagePreview = "MathFive.png",
                    DueDate = DateTime.Now,
                    StartDate = DateTime.Today,
                    ProjectColor = "Red"

                },
                new ProjectM
                {
                    ID = Guid.NewGuid().ToString(),
                    Subject = Subjects.PhysicalSciences,
                    ProjectName = "Example",
                    ProjectDescription = "A brief Explaination of how a projects item is previewed",
                    ImagePreview = "MathSeven.png",
                    DueDate = DateTime.Now,
                    StartDate = DateTime.Today,
                    ProjectColor = "Blue"

                }

            };

        }





        public List<ProjectM> GetProjects()
        {
            List<ProjectM> projects = new List<ProjectM>();

            projects = ProjectItems;

            return projects;
           

        }
        public void AddItem(ProjectM item)
        {
            try
            {

            List<ProjectM> ProjectTemplate = new List<ProjectM>();

            ProjectTemplate = ProjectItems;
            ProjectItems.Clear();
            
            ProjectTemplate.Add(item);
            ProjectItems = ProjectTemplate;
            }
            catch
            {
                Shell.Current.DisplayAlert("Error", "Please Re-Add Something went wrong", "OK");
            }


        }

        public void DeleteItem(ProjectM item)
        {

            try
            {
                List<ProjectM> ProjectTemplate = new List<ProjectM>();

                ProjectTemplate = ProjectItems;
                ProjectItems.Clear();

               int index = ProjectTemplate.IndexOf(item);

                ProjectTemplate.RemoveAt(index);


                ProjectItems = ProjectTemplate;


            }
            catch
            {
                Shell.Current.DisplayAlert("Error", "Please Re-Add Something went wrong", "OK");
            }

        }

        public ProjectM GetItemByID(string ID)
        {
           return ProjectItems.Where(x => x.ID == ID).FirstOrDefault();

        }


    }
}
