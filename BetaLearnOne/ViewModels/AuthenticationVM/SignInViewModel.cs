using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using BetaLearnOne.Services;
using BetaLearnOne.Models;
using BetaLearnOne.Views.Profile;

namespace BetaLearnOne.ViewModels.AuthenticationVM
{
   public class SignInViewModel : BaseViewModel
    {
        private string name;
        private string email;
        private string password;
        private string confirmPassword;
        private int passwordLevelBar;
        private string confirmColor = "Red";
        private int accesslevel = 0;

        UserData userdata = new UserData();

        public Command Signin { get; }
        public SignInViewModel()
        {
            Signin = new Command(OnSignIn);
           
        }



        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
                OnPropertyChanged(nameof(name));
            }
        }


        public string Email
        {
            get => email;
            set
            {
                SetProperty(ref email, value);
                OnPropertyChanged(nameof(email));
            }

        }

        public string Password
        {
            get => password;
            set
            {
                verifyPasswordLevel(Password);
                PasswordLevelBar = accesslevel;
                SetProperty(ref password, value);
                OnPropertyChanged(nameof(password));
            }
        }

        public string ConfirmPassword
        {
            get => confirmPassword;
            set
            {
                SetProperty(ref confirmPassword, value);
                passwordSame(value);
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        public int PasswordLevelBar
        {
            get => passwordLevelBar;
            set
            {
                SetProperty(ref passwordLevelBar, value);
                OnPropertyChanged(nameof(PasswordLevelBar));
            }
        }

        public string ConfirmColor
        {
            get => confirmColor;
            set
            {
                 
                SetProperty(ref confirmColor, value);
                OnPropertyChanged(nameof(ConfirmColor));
            }
        } 


        private bool VerifyInput()
        {
            if(!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void verifyPasswordLevel(string password)
        {


            int level = 0;
            if(password.Length >= 8)
            {
                level += 50;
            }
            else
            {
                level += 0;
            }



            List<int> numbers = new List<int>()
            {
               1,2,3,4,5,6,7,8,9,0
            };
            List<string> characters = new List<string>()
            {
                "!","@","#","$","%","^","&","*","+","=","-","`"
            };



            List<bool> ConditionOne = new List<bool>();
            List<bool> ConditionTwo = new List<bool>();





            foreach(var num in numbers)
            {
                if (password.IndexOf($"{num}") != -1)
                {
                    ConditionOne.Add(true);

                }
                else
                {
                    ConditionOne.Add(false);
                }
            }

            foreach(string cha in characters)
            {
                if(password.IndexOf(cha) != -1)
                {
                    ConditionTwo.Add(true);
                }
                else
                {
                    ConditionTwo.Add(false);
                }

            }

            if(ConditionOne.IndexOf(true) != -1)
            {
                level += 25;
            }
            else
            {

                level += 0;
            }
            if (ConditionTwo.IndexOf(true) != -1)
            {
                level += 25;
            }
            else
            {

                level += 0;
            }


            accesslevel = level;





        }

        private string passwordSame()
        {
            if (ConfirmPassword == Password)
            {
                return "Green";

            }
            else
            {
                return  "Red";
            }

        }


        private void passwordSame(string password)
        {
            if(password == Password)
            {
                ConfirmColor = "Green";

            }
            else
            {
                ConfirmColor = "Red";
            }

        }


        public bool Verified()
        {
            if (Name.Length != 0 && Email.Length != 0 && Password.Length != 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
           

        }

       async void OnSignIn()
        {
            verifyPasswordLevel(Password);
            if (VerifyInput())
            {
                var item = new User()
                {
                    Email = Email,
                    UserName = Name,
                    PassWord = Password,
                    Bio = "Edit your Bio!!",
                    ID = Guid.NewGuid().ToString(),
                    IsStaff = false
                };

                userdata.AddPerson(item);
                await Shell.Current.GoToAsync($"//{nameof(ProfilePage)}");



            }
            else
            {
                await Shell.Current.DisplayAlert("Alert", "Please Check your Input and try again", "OK");
            }

        }


    }
}
