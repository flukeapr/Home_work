using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Lab_styles_xaml.ViewModels;
using Lab_styles_xaml.Models;
using Lab_styles_xaml.View;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Lab_styles_xaml.APIs;
namespace Lab_styles_xaml.ViewModels
{
    class PageLoginViewModels : INotifyPropertyChanged
    {
         public LoginModels loginModels { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        APIService aPIService;

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

            aPIService = new APIService();

            LoginCommand = new Command(async() =>
            {
                var response = await aPIService.Login(loginModels);
                if (response)
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

