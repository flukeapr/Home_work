using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab_styles_xaml
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new View.PageLogin());
            MainPage = new NavigationPage(new View.TabbedPageProduct());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
