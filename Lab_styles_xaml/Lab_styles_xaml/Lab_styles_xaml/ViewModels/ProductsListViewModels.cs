using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Lab_styles_xaml.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Lab_styles_xaml.APIs;
using Xamarin.Essentials;


namespace Lab_styles_xaml.ViewModels
{
    class ProductsListViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Products> products {
            get
            {
                return myprod;
            }
        set
            {
                myprod = value;
                var args = new PropertyChangedEventArgs(nameof(products));
                PropertyChanged?.Invoke(this, args);
            }
        
        
        }
        public Command SelectCommand { get;  }
        public Command AddCommand { get; }
        public Command BackCommand { get; }
        public Products selectProduct { get; set; }

        APIService aPIService;

        ObservableCollection<Products> myprod;

        public ProductsListViewModels()
        {
            products = new ObservableCollection<Products>();

            aPIService = new APIService();

            GetProducts();

           

            SelectCommand = new Command(async() =>
            {
                var sendVar = new { selectProduct = selectProduct, BackCommand = BackCommand ,AddCommand = AddCommand};
                var ProdecutDetail = new View.ProductDetail
                {
                    BindingContext = sendVar
                };
                await Application.Current.MainPage.Navigation.PushModalAsync(ProdecutDetail);
            });
            AddCommand = new Command(async () =>
            {
                Order order = new Order();
                order.Title = selectProduct.Title;
                order.ProdID = selectProduct.ID;
                order.Price = selectProduct.Price;
                order.Username = Preferences.Get("username","");
                var response = await aPIService.AddOrder(order);
                if (response)
                {
                    await Application.Current.MainPage.DisplayAlert("Order", "Product added!!", "OK");
                }
            });
            BackCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });


        }

        async void GetProducts()
        {
            products = await  aPIService.GetProducts();
        }

    }
}
