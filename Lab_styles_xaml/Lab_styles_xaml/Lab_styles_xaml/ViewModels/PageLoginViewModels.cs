using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Lab_styles_xaml.ViewModels;
using Lab_styles_xaml.Models;
using Lab_styles_xaml.View;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Lab_styles_xaml.ViewModels
{
    class PageLoginViewModels : INotifyPropertyChanged
    {
         public LoginModels loginModels { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

       

        public string result;
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        
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

        public PageLoginViewModels()
        {
            loginModels = new LoginModels();

            LoginCommand = new Command(async() =>
            {
                

                if (loginModels.Email == "fluke@gmail.com" && loginModels.Password == "12345")
                {
                    Result = "Success";
                    await Application.Current.MainPage.Navigation.PushAsync(new View.TabbedPageProduct());
                }
                else
                {
                    Result = "Fail";
                }
                   
               
                



               



            });

            RegisterCommand = new Command( async() =>
            {
               
               await Application.Current.MainPage.Navigation.PushAsync(new View.PageRegister());
            });
        }
    }
}

