using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Collections.ObjectModel;
using Lab_styles_xaml.APIs;
using Lab_styles_xaml.Models;
using Xamarin.Forms;
namespace Lab_styles_xaml.ViewModels
{
    class CartViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Command LogoutCommand { get; }

        APIService aPIService;
        public ObservableCollection<Order> Orders
        {
            get
            {
                return myorders;
            }
            set
            {
                myorders = value;
                var args = new PropertyChangedEventArgs(nameof(Orders));
                PropertyChanged?.Invoke(this, args);
            }


        }
        ObservableCollection<Order> myorders;

        public CartViewModels()
        {
            Orders = new ObservableCollection<Order>();
            aPIService = new APIService();
            GetCart();

            LogoutCommand = new Command(async () => {


                var response = await aPIService.Logout();
                if (response)
                {
                    Application.Current.MainPage = new NavigationPage(new View.PageLogin());
                }
            
            
            
            });

        }
        async void GetCart()
        {
            Orders = await aPIService.getUserOrder();
        }

    }
}
