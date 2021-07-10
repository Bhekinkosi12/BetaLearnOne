using System;
using System.Collections.Generic;
using System.Text;
using BetaLearnOne.Models;
using SQLite;

namespace BetaLearnOne.Services.AuthenticationServices
{
   public interface IUserData
    {
        void AddAll(List<User> users);
        void AddUser(User user);
        void RemoveUser(User user);
        bool ReturnUser(string Email, string Password);
        void AddToLocalDB(User user);
        User ReturenLocalDB();
       




    }
}
