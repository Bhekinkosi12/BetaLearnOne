using System;
using System.Collections.Generic;
using System.Text;
using BetaLearnOne.Services;
using SQLite;


namespace BetaLearnOne.Models.ProjectModel
{
   public class ProjectM
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        
        public Subjects Subject { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string ImagePreview { get; set; }
        public string ProjectColor { get; set; }
        public string Notes { get; set; }
        public List<ProjectDataM> Data { get; set; }
        


        


        
        
        

    }
}
