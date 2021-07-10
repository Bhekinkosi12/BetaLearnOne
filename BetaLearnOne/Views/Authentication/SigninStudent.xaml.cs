using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BetaLearnOne.ViewModels.AuthenticationVM;

namespace BetaLearnOne.Views.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SigninStudent : ContentPage
    {
        private bool length;
        private bool isNumber;
        private bool isChar;
        private int progress;
        public SigninStudent()
        {
            InitializeComponent();
        }
        SignInViewModel signinViewModel = new SignInViewModel();

      

        private  void submit_Clicked(object sender, EventArgs e)
        {
            

        }

        private void confirmpassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsSame();
        }

        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            verifyPasswordLevels(password.Text);
        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {


        }


        


  
        private void IsSame()
        {
            if (password.Text == confirmpassword.Text)
            {
                BoxConfirmPassword.BackgroundColor = Color.Green;

            }
            else
            {
                BoxConfirmPassword.BackgroundColor = Color.Red;
            }

        }








        private bool Contails(string target, string list)
        {

            return target.IndexOfAny(list.ToCharArray()) != -1;
        }




        private void verifyPasswordLevels(string password)
        {



            if (password.Length >= 8)
            {
                length = true;
            }
            else
            {
                length = false;
            }




            List<int> numbers = new List<int>()
            {
               1,2,3,4,5,6,7,8,9,0
            };
            List<string> characters = new List<string>()
            {
                "!","@","#","$","%","^","&","*","+","=","-","`"
            };

            string charList = "!@#$%^&*()_+=-`.";
            string numberList = "1234567890";

            if (Contails(password, numberList))
            {
                isNumber = true;
            }
            else
            {
                isNumber = false;
            }



            if (Contails(password, charList))
            {
                isChar = true;
            }
            else
            {
                isChar = false;
            }



            if (!length)
            {
                progressPassword.Progress = getpercent(progressPassword.Progress, 0);
                BoxPassword.Color = Color.Red;
            }

            else if (length && isNumber && isChar)
            {
                progressPassword.Progress = getpercent(progressPassword.Progress, 3);
                BoxPassword.Color = Color.Green;
            }
            else if (length && isNumber && !isChar)
            {
                progressPassword.Progress = getpercent(progressPassword.Progress, 2);
                BoxPassword.Color = Color.Yellow;
            }
            else if (length && !isNumber && isChar)
            {
                progressPassword.Progress = getpercent(progressPassword.Progress, 2);
                BoxPassword.Color = Color.Yellow;
            }
            else
            {
                progressPassword.Progress = getpercent(progressPassword.Progress, 2);
                BoxPassword.Color = Color.Yellow;
            }





        }



        double getpercent(double current,int level)
        {

            if (level == 1)
            {

                if (current <= 50)
                {
                    return current + 25;
                }
                else
                {
                    return current;
                }




            }

            else if (level == 2)
            {

                if (current < 50)
                {
                    return current + 50;
                }
                else if(current == 50)
                {
                    return current;
                }
                else
                {
                    return 100;
                }




            }
            else if (level == 3)
            {
                return 100;
            }
            else
            {
                return current;
            }

        }





    }
}