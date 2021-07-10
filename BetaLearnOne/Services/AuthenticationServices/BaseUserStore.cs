using BetaLearnOne.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using BetaLearnOne.Models;
using Xamarin.Essentials;

namespace BetaLearnOne.Services.AuthenticationServices
{
    public class BaseUserStore : IUserData
    {
        private SQLiteConnection connection;
        private SQLiteConnection localDB;

        public void Init()
        {
            if (connection != null )
                return;

            var path = Path.Combine(FileSystem.AppDataDirectory , "UserData.db");
            connection = new SQLiteConnection(path);
            connection.CreateTable<User>();
            


        }

        public void LocalInit()
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, "LocalData.db");
            localDB = new SQLiteConnection(path);
            localDB.CreateTable<User>();
        }


        public void AddAll(List<User> users)
        {
            Init();
           
           foreach(var item in users)
            {
                connection.Insert(item);
            }

            

            

        }

        public void AddUser(User user)
        {
            Init();
          
           
            connection.Insert(user);
        }

        public void RemoveUser(User user)
        {
            Init();

            connection.Delete(user);

        }



        public bool ReturnUser(string Email, string Password)
        {
            Init();
            var data =  connection.Table<User>().Where(x => x.Email.ToLower() == Email.ToLower() && x.PassWord == Password).FirstOrDefault();

            if(data == null)
            {
                return false;
            }
            else
            {
                AddToLocalDB(data);
                return true;
            }

        }

       public void AddToLocalDB(User user)
        {
            LocalInit();
            localDB.Insert(user);

        }
       public User ReturenLocalDB()
        {
            LocalInit();
            return localDB.Table<User>().FirstOrDefault();

        }

    }
}
