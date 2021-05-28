using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using BetaLearnOne.Models;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;

namespace BetaLearnOne.Services
{
   public class UserData : IDataStore<User>
    {
       readonly List<User> Students;
       readonly List<User> Staff;
        private string StudentDataFile = "StudentDataBase.db";
        private string StaffDataFile = "StaffDataFile.db";



        private async void DataBase(string dataFile, List<User> list)
        {

            try
            {


                var dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dataFile );
                var data = new SQLiteConnection(dataPath);

                data.CreateTable<User>();

                foreach(var item in list)
                {
                    data.Insert(item);
                }
               
                
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }


       
        }

      


        private void AddDataToMemory(User user)
        {
            var dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Memory.db");
            var data = new SQLiteConnection(dataPath);
            data.CreateTable<User>();

            data.Insert(user);
          

            


        }


        public bool StudentUserData(string email,string password)
        {
            DataBase(StudentDataFile, Students);

            var dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), StudentDataFile);
            SQLiteConnection data = new SQLiteConnection(dataPath);
            
            var table =  data.Table<User>();
            
            

           var item = table.Where(x => x.PassWord == password && x.Email == email).FirstOrDefault();



            if(item != null)
            {
               AddDataToMemory(item);
                return true;

            }
            else
            {
                return false;
            }
            



        }

        public bool StaffUserData(string staffnumber, string password)
        {

            var dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), StaffDataFile);
            var data = new SQLiteConnection(dataPath);

            var table = data.Table<User>();
            var item = table.Where(x => x.PassWord == password && x.StaffNumber == staffnumber).FirstOrDefault();


            if (item != null)
            {
                return true;
            }
            else
            {
                return false;
            }



             
        }
       
        


        public UserData()
        {




            Students = new List<User>()
            {
                 new User
                 {
                     ID = Guid.NewGuid().ToString(),
                     UserName = "Ndumiso",
                     UserSurname = "Kubheka",
                     SchoolName = "Thistle Grove",
                     IsStaff = false,
                     Email = "ndumiso5154kk@gmail.com",
                     Phone = "0713083615",
                     Points = 240,
                     ProfilePicture = "mathSix.png",
                     StaffNumber = "",
                     PassWord = "ndumiso12@",
                     Bio = "School boy with no drama on the back of my head thinker",
                     
                     ProfileStrenght = 50,
                     
                     
                 }

            };




            Staff = new List<User>()
            {
                new User
                {
                     StaffNumber = "admin",
                     ID = Guid.NewGuid().ToString(),
                     Email = "ThistleGrove@gmail.com",
                     SchoolName = "Thistle Grove",
                     IsStaff = true,
                     ProfilePicture = "UiUserName.png",
                     UserName = "Mrs Kubheka",
                     PassWord = "admin"
                     
                    

                }

            };


            DataBase(StudentDataFile, Students);
            DataBase(StaffDataFile, Staff);

        }



        public void AddPerson(User user)
        {
            if (user.IsStaff)
            {
                Staff.Add(user);
                DataBase(StudentDataFile, Students);
            }
            else
            {

                 Students.Add(user);
                DataBase(StaffDataFile, Staff);
            }

        }


        public bool TryFindPersonEmail(string Email)
        {
            var user = Staff.Where(x => x.Email == Email).FirstOrDefault();
            if(user != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool TryFindPersonNumber(string number)
        {
            var user = Staff.Where(x => x.Phone == number).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public User FindPersonNumber(string number)
        {
            var def = new User()
            {
                Email = "admin",
                PassWord = "admin",
                ID = "admin",

            };



            var user = Staff.Where(x => x.Phone == number).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                return def;
            }

        }

        public User FindPersonEmail(string Email)
        {
            var def = new User()
            {
                 Email = "admin",
                 PassWord = "admin",
                 ID = "admin",
                 
            };



            var user = Staff.Where(x => x.Email == Email).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                return def;
            }

        }










        public User GetStaffAsync(string staffNumber)
        {

            var user = Staff.FirstOrDefault(x => x.StaffNumber == staffNumber);

            return user;
        }



        public  bool CheckUserInput(string email, string password)
        {
            var Pass = Students.Where(x => x.PassWord == password && x.Email == email).Select(c => c.Email) ;
            var a = from s in Students
                    where s.PassWord == password && s.Email == email
                    select s.Email;


            if (a.ToString().Length <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }

            

        }


        public async Task<bool> AddItemAsync(User item)
        {
            Students.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(User item)
        {
            var oldItem = Students.Where((User arg) => arg.ID == item.ID).FirstOrDefault();
            Students.Remove(oldItem);
            Students.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = Students.Where((User arg) => arg.ID == id).FirstOrDefault();
            Students.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<User> GetItemAsync(string id)
        {
            return await Task.FromResult(Students.FirstOrDefault(s => s.ID == id));
            
        }
       

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Students);
        }

        public async Task<User> ShowConditions(string email, string password)
        {
            return await Task.FromResult(Students.FirstOrDefault(s => s.Email == email && s.PassWord == password));
        }
    }
}
