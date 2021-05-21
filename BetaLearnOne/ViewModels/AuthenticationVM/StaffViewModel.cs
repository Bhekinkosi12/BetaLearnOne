using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using BetaLearnOne.Services;
using BetaLearnOne.Views.LearnView;

namespace BetaLearnOne.ViewModels.AuthenticationVM
{
    public class StaffViewModel : BaseViewModel
    {
        private string staffnumber;
        private string surname;
        private string email;
        private string phone;
        private string password;

        private UserData data = new UserData();
        public Command Login { get; }






        public string ID { get; set; }

        public string StaffNumber
        {
            get => staffnumber;
            set
            {
                SetProperty(ref staffnumber, value);
                OnPropertyChanged(nameof(StaffNumber));

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









        async void OnLogin()
        {

            bool condition = data.StaffUserData(StaffNumber, Password);

            if (condition == true)
            {
                await Shell.Current.GoToAsync($"//{nameof(LearnPage)}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Email or Password is incorrect", "OK");
            }

        }


    }
}
