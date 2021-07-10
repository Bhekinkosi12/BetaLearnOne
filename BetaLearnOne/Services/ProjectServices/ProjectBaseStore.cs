using System;
using System.Collections.Generic;
using System.Text;
using SQLitePCL;
using SQLite;
using BetaLearnOne.Models.ProjectModel;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Essentials;
using System.Linq;

namespace BetaLearnOne.Services.ProjectServices
{
   public  class ProjectBaseStore
    {
         SQLiteAsyncConnection connection;
        SQLiteConnection connections;

        public async void Init()
        {
            if (connection.Table<ProjectM>() != null ||  connections.Table<ProjectM>() != null)
                return;

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "Project.db" );
            connection = new SQLiteAsyncConnection(path);
            connections = new SQLiteConnection(path);
           await connection.CreateTableAsync<ProjectM>();
            


        }
        public async void AddItemAsync(ProjectM item)
        {
            Init();
          
           await connection.InsertAsync(item);

        }

        public void AddAllItems(List<ProjectM> items)
        {
            connections.InsertAll(items);
        }

        public  async void AddAllItemsAsync(List<ProjectM> itemsToAdd)
        {
            Init();
            await connection.InsertAllAsync(itemsToAdd);

        }

        public async void RemoveItemAsync(int index)
        {
            Init();
           await connection.DeleteAsync(index);


        }
        public async void RemoveItemByIDAsync(int id)
        {
            Init();
            var table = connection.Table<ProjectM>();
          var item = await  table.Where(x => x.Id == id).FirstOrDefaultAsync();
            await connection.DeleteAsync(item.Id);



        }

        
        public async Task<ProjectM> GetItemByIdAsync(int id)
        {
            Init();
            
            List<ProjectM> list = new List<ProjectM>();
            foreach (var item in await GetDataAsync())
            {
                list.Add(item);
            }


            //   return await Task.FromResult(connection.Table<ProjectM>().Where(x => x.Id == id).FirstOrDefaultAsync());
            return await Task.FromResult(list.FirstOrDefault(x => x.Id == id));

        }

      

        public List<ProjectM> GetData()
        {
            return connections.Table<ProjectM>().ToList();
        }
        public async Task<List<ProjectM>> GetDataAsync()
        {
            Init();

        // return  await Task.FromResult(connection.Table<ProjectM>().ToListAsync());
            return await await Task.FromResult(connection.Table<ProjectM>().ToListAsync());

        }

        public async Task<IEnumerable<ProjectM>> ReturnItemsAsync()
        {
            List<ProjectM> list = new List<ProjectM>();
            foreach(var item in await GetDataAsync())
            {
                list.Add(item);
            }
            return await Task.FromResult(list);
            

        }


    
      



    }
}
