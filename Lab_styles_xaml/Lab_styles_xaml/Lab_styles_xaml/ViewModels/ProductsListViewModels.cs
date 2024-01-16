using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Lab_styles_xaml.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Lab_styles_xaml.ViewModels
{
    class ProductsListViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Products> products { get; set; }
        public Command SelectCommand { get;  }
        public Command BackCommand { get; }
        public Products selectProduct { get; set; }

        public ProductsListViewModels()
        {
            products = new ObservableCollection<Products>();
            products.Add(new Products { ID = 1, Title = "Iphone 15", Description = "Apple", Price = 40000, Image = new Uri("https://www.notebookcheck.net/fileadmin/Notebooks/News/_nc3/iphone_15_pro_no_notch.jpg") });
            products.Add(new Products { ID = 2, Title = "Realme 7i", Description = "Realme", Price = 8000, Image = new Uri("https://th.bing.com/th/id/R.dc5b369f3d3d7724980cb79b30d087d6?rik=0z%2bskJEU0EqjKA&pid=ImgRaw&r=0") });


            SelectCommand = new Command(async() =>
            {
                var ProdecutDetail = new View.ProductDetail
                {
                    BindingContext = selectProduct
                };
                await Application.Current.MainPage.Navigation.PushModalAsync(ProdecutDetail);
            });

           


        }



    }
}
