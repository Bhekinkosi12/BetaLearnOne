using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using BetaLearnOne.Services;
using BetaLearnOne.Views.Profile;

namespace BetaLearnOne.ViewModels.AuthenticationVM
{
    public class ForgotPasswordViewModel : BaseViewModel
    {

        UserData userData = new UserData();

        private string email;
        private string number;
        private bool isEmail = true;
        private bool isNumber = false;

        public Command Check { get; }
        public Command SwitchMethod { get; }


        public bool IsNumber
        {
            get => isNumber;
            set
            {
                SetProperty(ref isNumber, value);
                OnPropertyChanged(nameof(IsNumber));
            }
        }
        public bool IsEmail
        {
            get => isEmail;
            set
            {
                SetProperty(ref isEmail, value);
                OnPropertyChanged(nameof(IsEmail));
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

        public string Number
        {
            get => number;
            set
            {
                SetProperty(ref number, value);
                OnPropertyChanged(nameof(Number));
            }
        }






        public ForgotPasswordViewModel()
        {
            Check = new Command(OnCheck);
            SwitchMethod = new Command(OnSwitch);
        }


       async void OnCheck()
        {
            if(IsEmail == true)
            {
                if (userData.TryFindPersonEmail(Email))
                {
                  var user =  userData.FindPersonEmail(Email);
                    user.IsStaff = false;

                    userData.AddPerson(user);
                    await Shell.Current.GoToAsync($"//{nameof(ProfilePage)}");
                }
                else
                {
                  await  Shell.Current.DisplayAlert("Sorry", "Your email is not recorgnised please SignIn", "OK");

                }


            }
            else
            {

                if (userData.TryFindPersonNumber(Number))
                {
                    var user = userData.FindPersonEmail(Number);
                    user.IsStaff = false;

                    userData.AddPerson(user);
                    await Shell.Current.GoToAsync($"//{nameof(ProfilePage)}");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Sorry", "Your number is not recorgnised please SignIn", "OK");

                }


            }

        }

        void OnSwitch()
        {
            if (IsEmail)
            {
                IsEmail = false;
                IsNumber = true;
            }
            else
            {
                IsEmail = true;
                IsNumber = false;
            }
        }


    }
}
