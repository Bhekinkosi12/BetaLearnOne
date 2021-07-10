using System;
using System.Collections.Generic;
using System.Text;
using BetaLearnOne.Models.ExamModel;
using System.Linq;
using Xamarin.Forms;
using System.IO;
using SQLite;
using System.Threading.Tasks;

namespace BetaLearnOne.Services.ExamDataStore
{
   public class ExamData
    {
        private string FileData = "ExamData.db";


        public List<Paper> MathExamPapers;
        public Dictionary<string, string[]> KeyedData = new Dictionary<string, string[]>();

        public ExamData()
        {
            ExamPaperData();

        }

         

        private void ExamPaperData()
        {
            MathExamPapers = new List<Paper>()
            {

                new Paper
                {
                    ID = Guid.NewGuid().ToString(),
                    QuestionPaper = "Math2014P1.pdf",
                    QuestionMemo = "Math2014P1Memo.pdf",
                    PaperName = "Mathemetics 2014 Paper 1",
                    PaperPath = "BetaLearnOne.Asserts.MathQP.Math2014P1.pdf",
                    MemoPath = "BetaLearnOne.Asserts.MathQP.Math2014P1Memo.pdf"
                },
                     new Paper
                {
                    ID = Guid.NewGuid().ToString(),
                    QuestionPaper = "Math2014P2.pdf",
                    QuestionMemo = "Math2014P2Memo.pdf",
                    PaperName = "Mathemetics 2014 Paper 2",
                    PaperPath = "BetaLearnOne.Asserts.MathQP.Math2014P2.pdf",
                    MemoPath = "BetaLearnOne.Asserts.MathQP.Math2014P2Memo.pdf"
                }


            };


            DataBase(FileData, MathExamPapers);



            foreach(var i in MathExamPapers )
            {
                string[] s = { i.PaperPath, i.MemoPath };
                AddDictionary(i.ID, s);   
            }



        }

        public Paper ItemByIndex(string positions)
        {
         

                return MathExamPapers[Int32.Parse(positions)];
          
 

        }

        public List<Paper> PaperData()
        {
            List<Paper> collect = new List<Paper>();
           collect = MathExamPapers;
            return collect;


        }
        public Paper ItemById(string id)
        {
            var dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), FileData);
            var data = new SQLiteConnection(dataPath);
            var table = data.Table<Paper>();

            return table.Where(x => x.ID == id).FirstOrDefault();

        }

        public Paper GetItemById(string id)
        {
           return MathExamPapers.FirstOrDefault(x => x.ID == id);

        }
        public async Task<Paper> GetItemAsync(string id)
        {
            return await Task.FromResult(MathExamPapers.FirstOrDefault(s => s.ID == id));
        }



        void AddDictionary(string id, string[] table)
        {
            KeyedData.Add(id, table);
        }
        public string[] ItemFromDictionary(string id)
        {
           return KeyedData[id];

        }






        private async void DataBase(string dataFile, List<Paper> list)
        {

            try
            {


                var dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dataFile);
                var data = new SQLiteConnection(dataPath);

                data.CreateTable<Paper>();

                foreach (var item in list)
                {
                    data.Insert(item);
                }


            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }



        }


    }
}
