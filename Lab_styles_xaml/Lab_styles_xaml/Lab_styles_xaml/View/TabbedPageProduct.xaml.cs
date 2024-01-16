using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab_styles_xaml.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPageProduct : TabbedPage
    {
        public TabbedPageProduct()
        {
            InitializeComponent();
        }
    }
}