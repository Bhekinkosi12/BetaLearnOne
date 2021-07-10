using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Xamarin.Essentials;
using Azure.Storage;

namespace BetaLearnOne.Services.TestServices
{
   public class TestDataBase
    {
       
        DirectoryInfo fileStore;
        DirectoryInfo[] downloadedModel;
        List<string> DataBases = new List<string>();
        Stream fileStoreStream;
        string path = Path.Combine(FileSystem.AppDataDirectory, @"\Module");
        public TestDataBase()
        {
            
        }

        void Init()
        {
            if (fileStore.Exists)
                return;
          
            Directory.CreateDirectory(path);

        }

        public List<string> GetItems()
        {
            Init();
            List<string> list = new List<string>();

             downloadedModel =  fileStore.GetDirectories(path,SearchOption.TopDirectoryOnly);


            foreach (var item in downloadedModel)
            {
                list.Add(item.Name);
                DataBases.Add(item.FullName);
            }

            return list;

        }


        


    }
}
