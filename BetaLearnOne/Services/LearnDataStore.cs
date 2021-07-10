using System;
using System.Collections.Generic;
using System.Text;
using BetaLearnOne.Models;

namespace BetaLearnOne.Services
{
   public class LearnDataStore
    {
        public List<Learn> MathSeqencesAndSeries;


        //Physics 
        private List<Learn> PhysicsMomentumAndImpuse;


        private List<Learn> DefaultList = new List<Learn>()
        {
               new Learn
                 {
                     ID = Guid.NewGuid().ToString(),
                      Topic = "BThis is the default item. no items are loaded please refresh",
                      Body =  "No Item",


                 }
        };

        public LearnDataStore()
        {
            SequencesAndSeries();
            MomentumAndImpulse();
            
        }



        public List<Learn> GetListByType(string type)
        {
            if(type == "MathSeqencesAndSeries")
            {
                return MathSeqencesAndSeries;
            }
            else if(type == "PhysicsMomentumAndImpuse")
            {
                return PhysicsMomentumAndImpuse;
            }
            else
            {
                
                    return DefaultList;
                
            }

             

        }



        /* ^^************
         *      Math 
         * 
         * **************
         */







        
        private void SequencesAndSeries()
        {
            MathSeqencesAndSeries = new List<Learn>()
            {
                 new Learn
                 {
                     ID = Guid.NewGuid().ToString(),
                      Topic = "By The end of this unit you should be able to do:",
                      Body =  "1. Number patterns, including arithmetics and geometric sequences and series  \n 2. Sigma Notation \n 3. Derivation and application of the formulae for the sum of arithmetic and geometric \n\n",


                 },
                 new Learn
                 {
                      ID = Guid.NewGuid().ToString(),
                      Topic = "A SEQUENCES is a number pattern in a definite order following a certain rule",
                      Body = "In an arithmetic sequence the diffence between two consecutive terms is constant \n\n For example : 1 ; 2; 3; 4; 5  \n\n d = (T2 - T1) or d = (T3 - T2) \n\n Fomula : T(n) = a + (n - 1) d \n\n ",


                 },
                 new Learn
                 {
                     ID = Guid.NewGuid().ToString(),
                     Topic = "Example",
                     Body =  "Take for example the sequence : \n      0 ; 2 ; 4 ; 6 ; 8 ;....  \n  The common difference is 2 and the general term of the sequence is : \n Tn = 0 + (n - 1)2 \n\n",


                 },
                 new Learn
                 {
                      ID = Guid.NewGuid().ToString(),
                      Topic = "A SERIES is a sum of terms in a sequence",
                      Body = " Serieses can be Denoted by \n       T1 + T2 + T3 + T4 ...  \n\n for example : 2 + 3 + 4 + 5... \n\n The sum formular : \n   S(n) = [a + (n - 1)d] \n\n",


                 },
                 new Learn
                 {
                      ID = Guid.NewGuid().ToString(),
                      Topic = "Examples: ",
                      Body =  "Example : \n The sum of the first 10 terms in an arithmetic progression is 50 and the sum of the next 10 terms is 250.Find the 13th term. \n\n" +
                                "Step 1 : \n   " +
                                "Sum of the first 10 terms : \n" +
                                "        S(10) = 50 \n " +
                                "        S(10) = 10/2[2a + (10 - 1)d] \n  " +
                                "           10 = 2a + 9d \n\n" +
                                "Step 2 : \n " +

                                "Sum of first 20 terms :\n " +
                                "            S(20) = 250 - 50 \n " +
                                "            S(10) = 20/2[2a + (20 - 1)d]  \n" +
                                "                  2a + 19d = 30 \n\n " +
                                "Step 3 : \n " +
                                "Solve step 1 and step 2 simultaneously \n   d = 2; a = -4 \n " +
                                "13th term = a + (13 -1)d \n "+
                                "          = -4 + 12(2) = 20",


                                

                 },
                 new Learn
                 {
                      ID = Guid.NewGuid().ToString(),
                      Topic = "A geometric series is a row in which each term is obtained by multiplying the previous term by the same quantity",
                      Body = "The quantity we multiply with each time is called the common ratio (r) \n " +
                "The common difference: r=Tn/Tn-1 \n"  +
                "Click options to get the General terms "

                 },
                 new Learn
                 {
                     ID = Guid.NewGuid().ToString(),
                     Topic = "Examples :",
                     Body = "Evaluate: 25 + 50 + 100 + … to 6 terms  \n" +
                "We need to check if this is an arithmetic series or a geometric series first. You should see that there is a common ratio of 2 because : \n 50/2 = 2 and 100/50 = 2 "  +
                " It is a geometric series and a = 25, n = 6, r = 2 \n" +
                "S(6) = 1 575"


                 }

            };

        }










        /* **********************
         * 
         *    Physical sciences
         * **********************
         */



        private void MomentumAndImpulse()
        {
            PhysicsMomentumAndImpuse = new List<Learn>()
            {
                new Learn
                {
                    ID = Guid.NewGuid().ToString(),
                    Topic = "Momentum is a physical quantity which is closely related to forces. Momentum is a property which applies to moving objects, in fact it is mass in motion. If something has mass and it is moving then it has momentum.",
                    Body = "The linear momentum of a particle (object) is a vector quantity equal to the product of the mass of the particle (object) and its velocity",
                    Hint = "The momentum (symbol p) of an object of mass m moving at velocity v is: p = m"


                },
                new Learn
                {
                    ID = Guid.NewGuid().ToString(),
                    Topic = "A car travelling at 120 km/hr will have a larger momentum than the same car travelling at 60 km/hr. Momentum is also related to velocity; the smaller the velocity, the smaller the momentum.",
                    Body = "Momentum is also vector quantity, because it is the product of a scalar (m) with a vector (v)",
                    Conclusion = "This means that whenever we calculate the momentum of an object, we should include the direction of the momentum"
                },
                new Learn
                {
                    ID = Guid.NewGuid().ToString(),
                    Topic = "A soccer ball of mass 420 g is kicked at 20 m·s^(−1) towards the goal post. Calculate the momentum of the ball.",
                    Hint = "Try to answer the practice question the steps are on the next slide"
                },
                new Learn
                {
                    ID = Guid.NewGuid().ToString(),
                    Topic = "Step 1: Identify what information is given and what is asked for: \n  The mass of the ball must be converted to SI units. 420 g = 0,42 kg We are asked to calculate the momentum of the ball. From the definition of momenetum, p = mv we see that we need the mass and velocity of the ball, which we are given.",
                    Body = "We calculate the magnitude of the momentum of the ball, \n   p = mv \n = (0,42) (20) \n = 8,40 kg·m·s^(−1)",
                    Conclusion = "Step 3: Quote the final answer \n We quote the answer with the direction of motion included, p = 8,40 kg·m·s^(−1) in the direction of the goal post."
                },
                new Learn
                {
                    ID = Guid.NewGuid().ToString(),
                    Topic = "An isolated system is a physical configuration of particles and or objects that we study that doesn’t exchange any matter with its surroundings and is not subject to any force whose source is external to the system.",
                    TopicImage = "MomentumFig1_1.jpg",

                },
                new Learn
                {
                    ID = Guid.NewGuid().ToString(),
                    Topic = "Conservation of Momentum The total momentum of an isolated system is constant.",
                    Body = "The total momentum of a system is calculated by the vector sum of the momenta of all the objects or particles in the system. For a system with n objects the total momentum is:",
                    Conclusion = "pT = p1 + p2 + ... + pn"
                },
                new Learn
                {
                    ID = Guid.NewGuid().ToString(),
                    Topic = "Two billiard balls roll towards each other. They each have a mass of 0,3 kg. Ball 1 is moving at v1 = 1 m·s^(−1) to the right, while ball 2 is moving at v2 = 0,8 m·s^(−1) to the left.Calculate the total momentum of the system.",
                    Hint = "Try to answer the practice question the steps are on the next slide"
                },
                new Learn
                {
                    ID = Guid.NewGuid().ToString(),
                    Topic = "Step 1: Identify what information is given and what is asked for :" +
        "We are asked to calculate the total momentum of the system. In this example our system consists of two balls. To find the total momentum we must determine the momentum of each ball and add them.\n pT = p1 + p2 Since ball 1 is moving to the right, its momentum is in this direction, while the second ball’s momentum is directed towards the left. Thus, we are required to find the sum of two vectors acting along the same straight line",
                    Body = "Step 2: Choose a frame of reference : \n  Let us choose moving to the right as the positive direction.",
                    Conclusion = "Step 3: Calculate the momentum \n  The total momentum of the system is then the sum of the two momenta taking the directions of the velocities into account. Ball 1 is travelling at 1 m·s^(−1) to the right or +1 m·s^(−1). Ball 2 is travelling at 0,8 m·s^(−1) to the left or −0,8 m·s^(−1). Thus, \n pT = m1v1 + m2v2 \n = (0,3) (+1) + (0,3) (−0,8) \n = (+0,3) + (−0,24) \n = +0,06 \n = 0,06 m·s^(−1) to the right. \n  In the last step the direction was added in words. Since the result in the second last line is positive, the total momentum of the system is in the positive direction (i.e. to the right)."

                }
                


            };

        }


    }
}
