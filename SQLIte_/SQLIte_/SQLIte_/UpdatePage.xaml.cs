using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLIte_
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePage : ContentPage
    {
        public SQLiteConnection connn;
        public Registration registration;
        public UpdatePage()
        {
            InitializeComponent();
            connn = DependencyService.Get<Isqlite>().GetConnection();

        }
        public void DisplayDetails()
        {
            Registration reg = new Registration();
            reg.id = ID.Text;
            reg.FirstName = FirstName.Text;
            reg.LastName = LastName.Text;
            reg.Dob = DOB.Date.ToString();
            reg.Email = Email.Text;
            reg.Password = Password1.Text;
            reg.Address = Address.Text;
            int x = 0;
            if (!string.IsNullOrEmpty(ID.Text) && !string.IsNullOrEmpty(FirstName.Text) && !string.IsNullOrEmpty(LastName.Text) && !string.IsNullOrEmpty(Email.Text))
            {
                try
                {
                    x = connn.Update(reg);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                if (x == 1)
                {
                    DisplayAlert("Update", "Update Finished", "OK");
                }
                else
                {
                    DisplayAlert("Update", "Update failled!!!", "Please try again", "ERROR");
                }



            }
            else
            {
                DisplayAlert("Required", "Not complete!!!!", "OK");
            }



        }
        private async void Update_clicked(object sender, EventArgs e)
        {
            DisplayDetails();
            await Navigation.PushModalAsync(new Display());
        }

        private void Cancel_clicked(object sender, EventArgs e)
        {
            ID.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            Email.Text = "";
            Password1.Text = "";
            Password2.Text = "";
            Address.Text = "";
        }
    
}
}