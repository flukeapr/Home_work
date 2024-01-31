using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLIte_
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Display : ContentPage
    {
        public SQLiteConnection connn;
        public Registration registration;
        ObservableCollection<string> itemlist;
        public Registration selected;

        public Command SelectCommand { get; set; }
        public Display()
        {
            InitializeComponent();
            connn = DependencyService.Get<Isqlite>().GetConnection();

            DisplayDetails();
            itemlist = new ObservableCollection<string>();
        }

        public void DisplayDetails()
        {
            var details = (from x in connn.Table<Registration>() select x).ToList();
            myListView.ItemsSource = details;
        }



        private async void myListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selected = e.SelectedItem as Registration;
            var resultN = new Registration
            {
                id = selected.id,
                FirstName = selected.FirstName,
                LastName = selected.LastName,
                Dob = selected.Dob,
                Email = selected.Email,
                Password = selected.Password,
                Address = selected.Address,

            };
            bool answer1 = await DisplayAlert("Do you want to Edit data?", "ID : " + selected.id.ToString() + "\n" + "Name : " + selected.FirstName.ToString(), "Yes", "No");
            if (answer1 == true)
            {
                UpdatePage newp = new UpdatePage();
                newp.BindingContext = resultN;
                await Navigation.PushModalAsync(newp);
            }
            else if (answer1 == false)
            {
                bool answer2 = await DisplayAlert("Do you want to Remove data ?", "ID : " + selected.id.ToString() + "\n" + "Name : " + selected.FirstName.ToString(), "Yes", "No");


                if (answer2 == true)
                {
                    int x = 0;
                    try
                    {
                        x = connn.Delete(resultN);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }


                }






            }

        }
    }
}

        
    