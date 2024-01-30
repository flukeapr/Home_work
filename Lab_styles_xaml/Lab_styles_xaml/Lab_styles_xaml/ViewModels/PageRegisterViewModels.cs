using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Lab_styles_xaml.Models;
using Lab_styles_xaml.APIs;

namespace Lab_styles_xaml.ViewModels
{
    class PageRegisterViewModels : INotifyPropertyChanged
    {
        public Command RegisterCommand { get; }
        public Command BackCommand { get; }

        APIService aPIService;
        public RegisterModels registerModels { get; set; }

        public string result;


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


        public PageRegisterViewModels()
        {
            registerModels = new RegisterModels();

            aPIService = new APIService();

            RegisterCommand = new Command(async () => {


               var response = await aPIService.Register(registerModels);

                if (response)
                {
                    await Application.Current.MainPage.DisplayAlert("Register", "Register success!!!", "OK");

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Register", "faillll!!!", "OK");
                }

            });

            


            BackCommand = new Command ( async() => {


              await  Application.Current.MainPage.Navigation.PopAsync();



            });

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
