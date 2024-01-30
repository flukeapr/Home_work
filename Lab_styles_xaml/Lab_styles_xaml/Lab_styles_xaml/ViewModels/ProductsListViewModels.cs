using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Lab_styles_xaml.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Lab_styles_xaml.APIs;
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
                var ProdecutDetail = new View.ProductDetail
                {
                    BindingContext = selectProduct
                };
                await Application.Current.MainPage.Navigation.PushModalAsync(ProdecutDetail);
            });

           


        }

        async void GetProducts()
        {
            products = await  aPIService.GetProducts();
        }

    }
}
