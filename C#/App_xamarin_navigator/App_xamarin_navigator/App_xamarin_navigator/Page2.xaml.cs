using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_xamarin_navigator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Command SubMitCommand { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public Page2()
        {

            InitializeComponent();

        }
        public void TxtUrl(object sender, EventArgs e)
        {
            Name = text.Text;
            Weburl.Source = "https://" + Name;


        }
    }
}