using System;
using System.Collections.Generic;
using BetaLearnOne.Models.ExamModel;

namespace BetaLearnOne.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string SubImage { get; set; }
        public int SubjectProgress { get; set; }
        public string SubBackground { get; set; }
        public string Document { get; set; }
        public List<Paper> List { get; set; }
    }
}