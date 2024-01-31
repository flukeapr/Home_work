using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Lab_Mvvm.Models;
using Lab_Mvvm.ViewModels;
using Xamarin.Forms;
using System.Collections.ObjectModel;
namespace Lab_Mvvm.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        Login login;

        public event PropertyChangedEventHandler PropertyChanged;

        public string email;

        public string password;

        public string result;
        public Command LoginCommand { get; }
        public Command ClearCommand { get; }

        public string Email
        {
            get => email;

            set
            {
                email = value;
                var arg = new PropertyChangedEventArgs(nameof(Email));
                PropertyChanged?.Invoke(this, arg);
            }
        }
        public string Password
        {
            get => password;

            set
            {
                password = value;
                var arg = new PropertyChangedEventArgs(nameof(Password));
                PropertyChanged?.Invoke(this, arg);
            }
        }
        public string Result
        {
            get => result;

            set
            {
                result = value;
                var arg = new PropertyChangedEventArgs(nameof(Result));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        public MainPageViewModel()
        {
            LoginCommand = new Command(() =>
            {
                Login login = new Login();
                login.Email = Email;
                login.Password = Password;
                this.Result = "UserName:" + login.Email + "Password:" + login.Password;


            });

            ClearCommand = new Command(() =>
            {
                this.Email = "";
                this.Password = "";           
            });
        }
    }
}
