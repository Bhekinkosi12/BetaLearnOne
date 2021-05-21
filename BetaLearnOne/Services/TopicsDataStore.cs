using System;
using System.Collections.Generic;
using System.Text;
using BetaLearnOne.Models;


namespace BetaLearnOne.Services
{
   public class TopicsDataStore 
    {
       public List<Topic> MathTopics;
        public List<Topic> PhysicsTopic;
        LearnDataStore Store = new LearnDataStore();





        private void physicsTopicData()
        {
            PhysicsTopic = new List<Topic>()
            {
                 new Topic
                 {

                       ID = Guid.NewGuid().ToString(),
                       TopicName = " Momentum and impulse",
                       TopicImage = "LearnPH4.png",
                       TopicProgress = 0,
                       TopicIntro = " In this chapter we will focus on what happens when two bodies undergo a contact interaction and how their motion is affected.",
                       TopicDataType = "PhysicsMomentumAndImpuse"


                 },
                 new Topic
                 {
                      ID = Guid.NewGuid().ToString(),
                      TopicName = "Vertical projectile motion",
                      TopicImage = "LearnPH4.png",
                      TopicProgress = 0,
                      TopicIntro = "In this chapter we are going to look at the motion of objects that are either projected thrown, or shot directly into the air, be it vertically upwards, downwards or whenobjects are dropped",
                      

                 },
                 new Topic
                 {
                     ID = Guid.NewGuid().ToString(),
                     TopicName = "Organic molecules",
                     TopicImage = "LearnPH4.png",
                     TopicProgress = 0,
                     TopicIntro = "Organic chemistry is the branch of chemistry that deals with organic molecules. An organic molecule is one which contains carbon, although not all compounds that contain carbon are organic molecules."



                 },
                 new Topic
                 {
                     ID = Guid.NewGuid().ToString(),
                     TopicName = "Work, energy and power",
                     TopicImage = "LearnPH6.jpeg",
                     TopicProgress = 0,
                     TopicIntro = "You will learn that work and energy are closely related to Newton’s laws of motion. You shall see that the energy of an object is its capacity to do work and doing work is the process of transferring energy from one object or form to another by means of a force.",


                 },
                 new Topic
                 {
                     ID = Guid.NewGuid().ToString(),
                     TopicName = "Doppler effect",
                     TopicImage = "LearnPH1.jpg",
                     TopicProgress = 0,
                     TopicIntro = "Have you noticed how the pitch of a police car or ambulance siren changes as it passes where you are standing, or how an approaching car or train sounds different to when it is tavelling away from you?"
                 },
                 new Topic
                 {
                      ID = Guid.NewGuid().ToString(),
                      TopicName = "Rate and Extent of Reaction",
                      TopicImage = "LearnPH4.png",
                      TopicProgress = 0,
                      TopicIntro = "In this chapter we will look at why reactions proceed at different rates (speeds) and how we can change the rate of the reaction."

                 },
                 new Topic
                 {
                      ID = Guid.NewGuid().ToString(),
                      TopicName = " Chemical equilibrium",
                      TopicImage = "LearnPH1.jpg",
                      TopicProgress = 0,
                      TopicIntro = "We will begin by exploring chemical equilibrium in more detail. Ways of measuring equilibrium and the factors that affect equilibrium will be covered."
                      
                 },
                 new Topic
                 {
                      ID = Guid.NewGuid().ToString(),
                      TopicName = "Acids and bases",
                      TopicImage = "LearnPH1.jpg",
                      TopicProgress = 0,
                      TopicIntro = "section deals with some models used to describe acids and bases. It is important to have a definition so that acids and bases can be correctly identified in reactions."
                 },
                 new Topic
                 {
                      ID = Guid.NewGuid().ToString(),
                      TopicName = "Electrodynamics",
                      TopicImage = "LearnPH4.png",
                      TopicProgress = 0,
                      TopicIntro = "This chapter describes how conductors moving in a magnetic field are applied in the real-world."

                 },
                 new Topic
                 {
                      ID = Guid.NewGuid().ToString(),
                      TopicName = "Optical phenomena and properties of matter",
                      TopicImage = "LearnPH2.jpg",
                      TopicProgress = 0,
                      TopicIntro = "In this chapter, we examine the process that is used to achieve this energy conversion."

                 }, 
                 new Topic
                 {
                     ID = Guid.NewGuid().ToString(),
                     TopicName = "Electrochemical reactions",
                     TopicImage = "LearnPH4.png",
                     TopicProgress = 0,
                     TopicIntro = "We use batteries throughout our day-to-day lives. Cell phones use lithium-ion batteries, cars use lead-acid batteries"
                 },
                 new Topic
                 {
                     ID = Guid.NewGuid().ToString(),
                     TopicName ="The chemical industry",
                     TopicImage = "LearnPH1.jpg",
                     TopicProgress = 0,
                     TopicIntro = "In this chapter we will investigate what fertilisers are, why they are important, how they are produced and what their impact on the environment is."
                 }
                 




            };



        }


        public Topic GetIdByItem(Topic item)
        {
            List<Learn> dItem = new List<Learn>();
            Topic defaultItem = new Topic()
            {
                TopicData = dItem
            };



          
            var mathtopic = MathTopics.IndexOf(item);
            var physicstopic = PhysicsTopic.IndexOf(item);

            if(mathtopic == -1 && physicstopic == -1)
            {
                return defaultItem;

            }
            else if(mathtopic != -1 && physicstopic == -1)
            {
                return MathTopics[mathtopic];
            }
            else if (mathtopic == -1 && physicstopic != -1)
            {
                return PhysicsTopic[physicstopic];

            }
            else
            {
                return defaultItem;
            }

        }




        private void mathTopicsData()
        {
            MathTopics = new List<Topic>()
            {
                new Topic
                {
                    ID = Guid.NewGuid().ToString(),
                    TopicName = "Sequences and Series",
                    TopicImage = "mathOne.png",
                    TopicProgress = 50,
                    TopicData = Store.MathSeqencesAndSeries,
                    TopicDataType = "MathSeqencesAndSeries"




                },
                new Topic
                {
                     ID = Guid.NewGuid().ToString(),
                    TopicName = "Fuctions",
                    TopicImage = "mathTwo.png",
                    TopicProgress = 10


                }
                ,
                new Topic
                {
                     ID = Guid.NewGuid().ToString(),
                    TopicName = "Algebra",
                    TopicImage = "mathThree.png",
                    
                    TopicProgress = 50

                },
                new Topic
                {
                     ID = Guid.NewGuid().ToString(),
                    TopicName = "Graphs",
                    TopicImage = "mathFour.png",
                    TopicProgress = 100

                }



            };

        }



        public TopicsDataStore()
        {
            mathTopicsData();
            physicsTopicData();
        }


    }
}
