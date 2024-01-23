using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using SQLitePCL;
using System.IO;

using Xamarin.Forms.Xaml;



namespace SQLIte_
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        public SQLiteConnection connn;
        public Registration registration;
        public MainPage()
        {
            InitializeComponent();
            connn = DependencyService.Get<Isqlite>().GetConnection();
            connn.CreateTable<Registration>();

        }
        private void Sigup_Ckicked(object sender, EventArgs e)
        {
            Registration reg = new Registration();

            reg.id = ID.Text;
            reg.FirstName = FirstName.Text;
            reg.LastName = LastName.Text;
            reg.Dob = DOB.Date.ToString();
            reg.Email = Email.Text;
            reg.Password = Password.Text;
            reg.Address = Address.Text;
            int x = 0;

            if (!string.IsNullOrEmpty(ID.Text) && !string.IsNullOrEmpty(FirstName.Text) && !string.IsNullOrEmpty(LastName.Text) && !string.IsNullOrEmpty(Email.Text))
            {

                try
                {
                    x = connn.Insert(reg);


                }
                catch (Exception ex)
                {


                    throw ex;
                }
                if (x == 1)
                {
                    DisplayAlert("Registration", "Thanks for Registration", "Cancel");
                }
                else
                {
                    DisplayAlert("Registration Failled!!", "Please try again", "ERROR");
                }
            }
            else
            {
                DisplayAlert("Registration Failled!!", "Not Complete!!!", "ERROR");
            }
        }





        private async void Show_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushModalAsync(new Display());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Retiriew fail", "please try again", "ERROR");
                throw ex;
            }
        }

    }
}
