using System;
using System.Collections.Generic;
using System.Text;
using BetaLearnOne.Models.ProjectModel;
using BetaLearnOne.Services;
using Xamarin.Forms;
using System.Linq;
using BetaLearnOne.Services.ProjectServices;
using System.Threading.Tasks;

namespace BetaLearnOne.Services
{
   public class ProjectData
    {
        ProjectBaseStore BaseStore = new ProjectBaseStore();
        private List<ProjectM> ProjectItems { get; set; }
      
        

        public ProjectData()
        {
            ProjectDataAcess();
           // BaseStore.AddAllItemsAsync(ProjectItems);
           // BaseStore.AddAllItems(ProjectItems);
        }


        private void ProjectDataAcess()
        {

            ProjectItems = new List<ProjectM>()
            {
                new ProjectM
                {
                    Id = 1,
                    Subject = Subjects.Mathametics,
                    ProjectName = "Example",
                    ProjectDescription = "A brief Explaination of how a projects item is previewed",
                    ImagePreview = "MathFive.png",
                    DueDate = DateTime.Now,
                    StartDate = DateTime.Today,
                    ProjectColor = "Red",
                    Data = new List<ProjectDataM>()
                    {
                       new ProjectDataM
                       {
                           ID = 1,
                           Description = "You can add new steps here",
                            Hint = "It works better if you try it"
                       },
                        new ProjectDataM
                       {
                           ID = 1,
                           Description = "You can add new steps here",
                            Hint = "It works better if you try it"
                       },
                        new ProjectDataM
                       {
                           ID = 1,
                           Description = "You can add new steps here",
                            Hint = "It works better if you try it"
                       }
                    },
                    Notes = "We are proud to manifest the tradition of making something posible and giving back to the community making people smile is our goal"

                },
                new ProjectM
                {
                    Id = 2,
                    Subject = Subjects.PhysicalSciences,
                    ProjectName = "Example",
                    ProjectDescription = "A brief Explaination of how a projects item is previewed",
                    ImagePreview = "MathSeven.png",
                    DueDate = DateTime.Now,
                    StartDate = DateTime.Today,
                    ProjectColor = "Blue",
                     Data = new List<ProjectDataM>()
                    {
                       new ProjectDataM
                       {
                           ID = 1,
                           Description = "You can add new steps here",
                            Hint = "It works better if you try it"
                       },
                       new ProjectDataM
                       {
                           ID = 1,
                           Description = "You can add new steps here",
                            Hint = "It works better if you try it"
                       },
                       new ProjectDataM
                       {
                           ID = 1,
                           Description = "You can add new steps here",
                            Hint = "It works better if you try it"
                       }
                    },
                       Notes = "We are proud to manifest the tradition of making something posible and giving back to the community making people smile is our goal"

                }

            };

        }



        public void AddNote(int ProjectId,ProjectDataM itemToAdd)
        {
            var i = ProjectItems.FirstOrDefault(x => x.Id == ProjectId).Data;
            i.Add(itemToAdd);

        }
        public List<ProjectDataM> GetNoteData(int ProjectId)
        {
            return ProjectItems.FirstOrDefault(x => x.Id == ProjectId).Data;
        }
        public ProjectDataM GetNote(int ProjectID,int NoteId)
        {
            return ProjectItems.FirstOrDefault(x => x.Id == ProjectID).Data.FirstOrDefault(i => i.ID == NoteId);
        }
        public void UpdateNote(int ProjectID,int NoteId, ProjectDataM NewItem)
        {
          var item =  ProjectItems.FirstOrDefault(x => x.Id == ProjectID).Data.FirstOrDefault(i => i.ID == NoteId);
            item = NewItem;

        }
        public void RemoveNoteItem(int ProjectId, ProjectDataM item)
        {
           var list = ProjectItems.FirstOrDefault(x => x.Id == ProjectId).Data;
            list.Remove(item);

        }





        public List<ProjectM> ReturningProjects()
        {
            return ProjectItems;

        }
        public void AddingItem(ProjectM item)
        {
            ProjectItems.Add(item);


        }
        public void RemovingItem(ProjectM itemToDelete)
        {
            ProjectItems.Remove(itemToDelete);
        }
        public ProjectM ReturningItemById(int id)
        {
          return ProjectItems.FirstOrDefault(x => x.Id == id);

        }
       public void UpdatingItemNote(string note,int projectIndex)
        {
           var item = ProjectItems.FirstOrDefault(x => x.Id == projectIndex);
            item.Notes = note;

        }
        public void UpdateItemDescription(string description, int projectIndex)
        {
            var item = ProjectItems.FirstOrDefault(x => x.Id == projectIndex);
            item.ProjectDescription = description;
        }





        public async Task<List<ProjectM>> GetProjects()
        {
           






           return await BaseStore.GetDataAsync();

            
           

        }
        public void AddItem(ProjectM item)
        {
            try
            {
                BaseStore.AddItemAsync(item);
          
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
                BaseStore.RemoveItemAsync(item.Id);


            }
            catch
            {
                Shell.Current.DisplayAlert("Error", "Please Re-Add Something went wrong", "OK");
            }

        }

      
        
        


    }
}
