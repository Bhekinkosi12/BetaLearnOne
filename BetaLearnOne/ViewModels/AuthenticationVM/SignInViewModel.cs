using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using BetaLearnOne.Services;
using BetaLearnOne.Models;
using BetaLearnOne.Views.Profile;
using BetaLearnOne.Services.AuthenticationServices;

namespace BetaLearnOne.ViewModels.AuthenticationVM
{
   public class SignInViewModel : BaseViewModel
    {
        private string name;
        private string email;
        private string password;
        private string confirmPassword;
        

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

                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }


   

        private bool VerifyInput()
        {



            if(!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
            {
                int isEmail = Email.IndexOf('@');
                int Long = Password.Length;

                if(isEmail != -1 && Long >= 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
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
            try
            {

            if (VerifyInput())
            {
                try
                {
                    IUserData basedata = new BaseUserStore();
                    var item = new User()
                    {
                        Email = Email,
                        UserName = Name,
                        PassWord = Password,
                        Bio = "Edit your Bio!!",

                        IsStaff = false
                    };
                    basedata.AddUser(item);

                    await Shell.Current.GoToAsync($"//{nameof(TabbedPage)}");


                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
                }
                

            }
            else
            {
                await Shell.Current.DisplayAlert("Alert", "Please level all indicators to green", "OK");
            }


            } catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }

        }


    }
}
