using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using BetaLearnOne.Services;
using BetaLearnOne.Models;
using BetaLearnOne.Views.LearnView;

namespace BetaLearnOne.ViewModels.AuthenticationVM
{
   public class StudentViewModel : BaseViewModel
    {
        private string username;
        private string surname;
        private string email;
        private string phone;
        private string password;




       private UserData data = new UserData();
        public Command Login { get; }

        public StudentViewModel()
        {
            Login = new Command(OnLogin);
        }







        public string ID { get; set; }

        public string UserName
        {
            get => username;
            set
            {
                SetProperty(ref username, value);
                OnPropertyChanged(nameof(UserName));

            }
        }

        public string Password
        {
            get => password;
            set
            {
                SetProperty(ref password, value);
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Surname
        {
            get => surname;
            set
            {
                SetProperty(ref surname, value);
                OnPropertyChanged(nameof(Surname));

            }
        }
        public string Email
        {
            get => email;
            set
            {
                SetProperty(ref email, value);
                OnPropertyChanged(nameof(Email));

            }
        }


        public string Phone
        {
            get => phone;
            set
            {
                SetProperty(ref phone, value);
                OnPropertyChanged(nameof(Phone));
            }
        }
















        public bool Verified()
        {
            bool condition = data.StudentUserData(Email, Password);

            if(condition == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        async void OnLogin()
        {

            bool condition = data.StudentUserData(Email, Password);

            if(condition == true)
            {
               await Shell.Current.GoToAsync($"{nameof(LearnPage)}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Email or Password is incorrect", "OK");
            }


            /*

           bool condtion = data.CheckUserInput(email, password);
            var item = await data.ShowConditions(email, password);
            
            if(string.IsNullOrEmpty(item.ID))
            {
                await Shell.Current.GoToAsync($"//{nameof(LearnPage)}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Email or Password is incorrect", "OK");
            }
            */
            
        }


    }
}
