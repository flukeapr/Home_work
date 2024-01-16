using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Lab_styles_xaml.Models;

namespace Lab_styles_xaml.ViewModels
{
    class PageRegisterViewModels : INotifyPropertyChanged
    {
        public Command RegisterCommand { get; }
        public Command BackCommand { get; }

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

            RegisterCommand = new Command(() => {

                if(registerModels.Email=="newacc@gmail.com" && registerModels.Password == "12345" && registerModels.ConfirmPass== registerModels.Password)
                {

                    Result = "Create New Account Success";
                }else if (registerModels.ConfirmPass != registerModels.Password)
                {
                    Result = "Pleace Check you Confirm Password";

                }
                else
                {
                    Result = "fail";
                }


                

            });


            BackCommand = new Command ( async() => {


              await  Application.Current.MainPage.Navigation.PopAsync();



            });

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
