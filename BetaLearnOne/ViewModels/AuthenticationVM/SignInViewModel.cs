using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLearnOne.ViewModels.AuthenticationVM
{
   public class SignInViewModel : BaseViewModel
    {
        private string name;
        private string email;
        private string password;
        private string confirmPassword;
        private int passwordLevelBar;
        private string confirmColor;


        public SignInViewModel()
        {
           
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
                SetProperty(ref password, value);
                verifyPasswordLevel(value);
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
            get => passwordSame();
            set
            {
                 
                SetProperty(ref confirmColor, value);
                OnPropertyChanged(nameof(ConfirmColor));
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


            foreach(var num in numbers)
            {
                if (password.IndexOf($"{num}") != -1)
                {
                    level += 25;

                }
                else
                {
                    level += 0;
                }
            }

            foreach(string cha in characters)
            {
                if(password.IndexOf(cha) != -1)
                {
                    level += 25;
                }
                else
                {
                    level += 0;
                }

            }





            PasswordLevelBar = level;





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


    }
}
