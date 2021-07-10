using BetaLearnOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetaLearnOne.Services.ExamDataStore;


namespace BetaLearnOne.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        TopicsDataStore dataStore = new TopicsDataStore();

        ExamData examData = new ExamData();
        

        
         
        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Math.png", Description="Mathematics" , Document = "MathMTG.pdf" ,SubBackground = "mathTwo.png" , SubjectProgress = 40, List = examData.MathExamPapers },
                   new Item { Id = Guid.NewGuid().ToString(), Text = "Math.png", Description="Mathematics Lite", Document = "MathLite.pdf" ,SubBackground = "mathTwo.png" , SubjectProgress = 10 },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Physics.png", Description="Phyisical Sciences", SubBackground = "LearnPH1.jpg" ,SubjectProgress = 14,Document = "PhysicalSciencesG12.pdf" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "life_science.png", Description="Life Sciences", SubjectProgress = 10,Document = "LifeSciences2017.pdf" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Computer.png", Description="Application Technology",SubjectProgress = 80 ,Document = "Computer.pdf" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Languages.png", Description="Languages",SubjectProgress = 0, Document = "AfikaansTaal.pdf" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "LO.png", Description="Life Orientaions",SubjectProgress = 40 },
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public Task<Item> ShowConditions(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}