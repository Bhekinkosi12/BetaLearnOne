using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.CommunityToolkit.Extensions;
using BetaLearnOne.Models;
using SQLite;
using System.IO;
using Xamarin.forms;


namespace BetaLearnOne.ViewModels.ProfileVM
{
   public class ProfileViewModel : BaseViewModel
    {
        private string profilePicture;
        private string userName;
        private int level;
        private int points;
        private string bio;
        private int profileStrenght;
        private ObservableCollection<User> rewards;
        public Command Edit { get; }
       
       


        public string UserName
        {
            get => userName;
            set
            {
                SetProperty(ref userName, value);
                OnPropertyChanged(nameof(UserName));
            }
        }

        public int Level
        {
            get => level;
            set
            {
                SetProperty(ref level, value);
                OnPropertyChanged(nameof(Level));
            }
        }
        public int Points
        {
            get => points;
            set
            {
                SetProperty(ref points, value);
                OnPropertyChanged(nameof(Points));
            }
        }
        public string Bio
        {
            get => bio;
            set
            {
                SetProperty(ref bio, value);
                OnPropertyChanged(nameof(Bio));
            }
        }
        public int ProfileStrenght
        {
            get => profileStrenght;
            set
            {
                SetProperty(ref profileStrenght, value);;
                OnPropertyChanged(nameof(ProfileStrenght));
            }
        }






        private void AccesData()
        {
            var dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Memory.db");
            var data = new SQLiteConnection(dataPath);

            var table = data.Table<User>().FirstOrDefault();

            if (table == null)
                return;

            UserName = table.UserName;
            Level = Getlevel(table.Points);
            Bio = table.Bio;
            ProfileStrenght = table.ProfileStrenght;

            


        }

        public ProfileViewModel()
        {
            AccesData();
            Edit = new Command(OnEdit);
        }



        void OnEdit()
        {
            
            Shell.Current.ShowPopup(new ProfileEdit());
        }

        private int Getlevel(int points)
        {

            double a = points / 1000;

            int b = Int32.Parse(Math.Floor(a).ToString());

            if (b < 2)
            {
                return 1;
            }
            else
            {
                return b;
            }




        }


    }
}
