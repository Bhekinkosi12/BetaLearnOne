using System;
using System.Collections.Generic;
using System.Text;
using BetaLearnOne.Models;

namespace BetaLearnOne.Services
{
   public class QuizDataStore
    {
        private List<Quiz> MathSequencesAndSeriesAO;
        private List<Quiz> MathSequencesAndSeriesOP;


        public QuizDataStore()
        {
            AOSequencesAndSeries();
        }

        void AOSequencesAndSeries()
        {
            MathSequencesAndSeriesAO = new List<Quiz>()
            {
                new Quiz
                {
                    Topic = "MathSeqencesAndSeries",
                    ID = Guid.NewGuid().ToString(),
                    Question1 = "-3/9 ; a; b; 2/9 form a geometric sequence, find a and b.",
                    Answer1 = "0.5" ,
                    Answer2 = "-1/3",
                    Hint = "Use '/' for divide operator"
                    

                },
                new Quiz
                {
                    Topic = "MathSeqencesAndSeries",
                    ID = Guid.NewGuid().ToString(),
                    Question1 = "For the geometric sequence with T5 = 486 and r = 3:",
                    Question2 =  "If the last term in the sequence is 118 098, use the general rule to calculate how many terms there are in the sequence?",
                    Answer1 = "n = 10",
                    Hint = "Tn = 6.3^(n-1)",


                },
                new Quiz
                {
                    Topic = "MathSeqencesAndSeries",
                    ID = Guid.NewGuid().ToString(),
                    Question1 = "Give the rule for the following sequence: 0 ; 10 ; 24 ; 42 ; 64...",
                    Answer1 = "2n^2 + 4n - 6",
                    Hint = "Avoid 'Tn ='. Use '^' for power and leave space between operators like: \n 5x^4 + 4"

                },
                  new Quiz
                {
                    Topic = "MathSeqencesAndSeries",
                    ID = Guid.NewGuid().ToString(),
                    Question1 = "Given the sequence: -8; -2; 4;....",
                    Question2 = "State whether it is arithmetic, geometric or neither",
                    Question3 = "Write down the next term of the sequence ",
                    Question4 = "Find an expression for the nth term.",
                    Answer1 = "Arithmetic".ToLower(),
                    Answer2 = "10",
                    Answer3 = "6n - 14",
                     Hint = "Avoid 'Tn ='. Use '^' for power and leave space between operators like: \n 5x^4 + 4"



                  },
                  new Quiz
                {
                    Topic = "MathSeqencesAndSeries",
                    ID = Guid.NewGuid().ToString(),
                    Question1 = "Determine the value of the 15th term of the sequence: ",
                    Question2 = "1; 3; 6; 10; 15; 21;...",
                    Answer1 = "120",
                    Hint = "Answer Only",





                  },
                  new Quiz
                  {
                      Topic = "MathSeqencesAndSeries",
                    ID = Guid.NewGuid().ToString(),
                    Question1 = "Given the arithmetic sequence 16; 11; 6;...",
                    Question2 = "Write down the next term.",
                    Question3 = "Find an expression for the n-th term.",
                    Answer1 = "1",
                    Answer2 = "21 - 5n",
                    Hint = "leave space between operators like: \n 5x^4 + 4"
                  },
                  new Quiz
                  {
                    Topic = "MathSeqencesAndSeries",
                    ID = Guid.NewGuid().ToString(),
                    Question1 = "The first three terms of an arithmetic sequence are: ",
                    Question2 = "(m - 2); (2m - 6); (4m - 8) ..",
                    Question3 = "Find The value of m",
                    Answer1 = "2" ,
                    Hint = "Answer Only"



                  },
                   new Quiz
                  {
                    Topic = "MathSeqencesAndSeries",
                    ID = Guid.NewGuid().ToString(),
                    Question1 = "Consider the geometric sequence: -3/2 ; 3 ; - 6 ;",
                    Question2 = "Which term in the sequence is equal to -96",
                    Answer1 = "7",
                    Hint = "Answer Only"



                   }


            };
        }







    }
}
