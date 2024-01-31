using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using Lab_Mvvm.Models;
using System.ComponentModel;

namespace Lab_Mvvm.ViewModels
{
    class ProductListViewModel 
    {



        Product product;

      
        public ObservableCollection<Product> Products { get; set; }
        
        public ProductListViewModel()
        {
            LoadData();
        }
        public void LoadData()
        {

            Products = new ObservableCollection<Product>();
            Product p1 = new Product();
            p1.ID = 1;
            p1.Title = "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops";
            p1.Description = "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday";
            p1.Price = 109.95f;
            p1.Image = new Uri("https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg");
            Products.Add(p1);
            Product p2 = new Product();
            p2.ID = 2;
            p2.Title = "Mens Casual Premium Slim Fit T-Shirts";
            p2.Description = "Slim-fitting style, contrast raglan long sleeve, three-button henley placket, light weight & soft fabric for breathable and comfortable wearing. And Solid stitched shirts with round neck made for durability and a great fit for casual fashion wear and diehard baseball fans. The Henley style round neckline includes a three-button placket.";
            p2.Price = 22.3f;
            p2.Image = new Uri("https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_.jpg");
            Products.Add(p2);
            Product p3 = new Product();
            p3.ID = 3;
            p3.Title = "Mens Cotton Jacket";
            p3.Description = "great outerwear jackets for Spring/Autumn/Winter, suitable for many occasions, such as working, hiking, camping, mountain/rock climbing, cycling, traveling or other outdoors. Good gift choice for you or your family member. A warm hearted love to Father, husband or son in this thanksgiving or Christmas Day.";
            p3.Price = 55.99f;
            p3.Image = new Uri("https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_.jpg");
            Products.Add(p3);




        }

    }

    }

