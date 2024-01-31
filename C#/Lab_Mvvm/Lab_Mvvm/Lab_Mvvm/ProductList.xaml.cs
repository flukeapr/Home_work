using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab_Mvvm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductList: ContentPage
    {
        public ProductList()
        {
            InitializeComponent();
        }
    }
}