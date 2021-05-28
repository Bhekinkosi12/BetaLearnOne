using System;
using System.Collections.Generic;
using System.Text;
using BetaLearnOne.Models.ExamModel;
using System.Linq;
using Xamarin.Forms;
using System.IO;
using SQLite;

namespace BetaLearnOne.Services.ExamDataStore
{
   public class ExamData
    {
        private string FileData = "ExamData";
       public List<Paper> MathExamPapers;

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
                    QuestionPaper = "Math2014P1.pdf",
                    QuestionMemo = "Math2014P1Memo.pdf",
                    PaperName = "Mathemetics 2014 Paper 1",
                    PaperPath = "BetaLearnOne.Asserts.MathQP.Math2014P1.pdf",
                    MemoPath = "BetaLearnOne.Asserts.MathQP.Math2014P1Memo.pdf"
                }


            };

            DataBase(FileData, MathExamPapers);

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
