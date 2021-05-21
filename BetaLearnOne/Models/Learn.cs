using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLearnOne.Models
{
   public class Learn
    {
        public string ID { get; set; }
        public string Topic { get; set; }

        public string TopicImage { get; set; }

        public string Body { get; set; }
        public string BodyImage { get; set; }

        public string Conclusion { get; set; }
        public string ConclusionImage { get; set; }


        public string Hint { get; set; }
    }
}
