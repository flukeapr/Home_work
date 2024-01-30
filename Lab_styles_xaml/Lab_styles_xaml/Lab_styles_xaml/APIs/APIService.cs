using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Lab_styles_xaml.Models;
using Newtonsoft.Json;

namespace Lab_styles_xaml.APIs
{
    class APIService
    {
        HttpClient client;
        public APIService()
        {
            client = new HttpClient();

        }
        public async Task<ObservableCollection<Products>> GetProducts()
        {
            ObservableCollection<Products> Item = null;

            try
            {
                var response = await client.GetAsync("http://10.0.2.2:52317/api/Products");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Item = JsonConvert.DeserializeObject<ObservableCollection<Products>>(content);
                    return Item;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return null;
        }





    }
}
