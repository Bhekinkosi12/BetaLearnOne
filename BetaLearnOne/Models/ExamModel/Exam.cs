using System;
using System.Collections.Generic;
using System.Text;
using BetaLearnOne.Services;

namespace BetaLearnOne.Models.ExamModel
{
   public class Exam 
    {
        public string ID { get; set; }
        public string Subject { get; set; }
        public List<Paper> Papers { get; set; }
        public string FilePath { get; set; }
        
       
      


    }
}
