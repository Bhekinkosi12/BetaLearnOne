using System;
using System.Collections.Generic;
using System.Text;


namespace BetaLearnOne.Models
{
   public class Topic
    {
        public string ID { get; set; }
        public string TopicName { get; set; }
        public string TopicImage { get; set; }
        public int TopicProgress { get; set; }
        public string TopicIntro { get; set; }
             
        
        public List<Learn> TopicData { get; set; }
        public string TopicDataType { get; set; }


    }
}
