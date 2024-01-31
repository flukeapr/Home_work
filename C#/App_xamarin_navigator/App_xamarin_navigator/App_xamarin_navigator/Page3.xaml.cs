using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_xamarin_navigator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        ObservableCollection<string> itemList;
        string itemSelected
        ;
        public Page3()
        {
            InitializeComponent();
            itemList = new ObservableCollection<string>();
            itemList.Add("FFFFFF");
            itemList.Add("FFFF00");
            itemList.Add("FF00FF");
            itemList.Add("00FFFF");
            itemList.Add("FFF000");
            itemList.Add("000FFF");
            lstview.ItemsSource = itemList;
        }

        public void AddList_Clicked(object sender, EventArgs e)
        {
            itemList.Add("AAAAAA");
        }
        public void DelList_Clicked(object sender, EventArgs e)
        {
            itemList.Remove(itemSelected);
        }
        public async void ListBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private void lst_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            itemSelected = e.SelectedItem.ToString();
        }
    }
}