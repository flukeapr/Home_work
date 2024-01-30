using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Lab_styles_xaml.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;

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
        public async Task<bool> Register(RegisterModels Item)
        {
            try
            {
                string json= JsonConvert.SerializeObject(Item);

                StringContent sContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://10.0.2.2:61071/api/Account/Register", sContent);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }


        }

        public async Task<bool> Login(LoginModels login)
        {
            User Item = null;
            try
            {
                var dict = new Dictionary<string, string>();
                dict.Add("Content-Type", "application/x-www-form-urlencode");
                dict.Add("grant_type", "password");
                dict.Add("username", login.Email);
                dict.Add("password", login.Password);
                var response = await client.PostAsync("http://10.0.2.2:61071/token", new FormUrlEncodedContent(dict));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Item = JsonConvert.DeserializeObject<User>(content);
                    Preferences.Set("username", Item.userName);
                    Preferences.Set("token_type", Item.token_type);
                    Preferences.Set("access_token", Item.access_token);

                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return false;
        }
        public async Task<bool> AddOrder(Order Item)
        {
            try
            {
                string json = JsonConvert.SerializeObject(Item);

                StringContent sContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://10.0.2.2:52317/api/orders", sContent);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }


        }
        public async Task<ObservableCollection<Order>> getUserOrder()
        {
            ObservableCollection<Order> Item = null;
            var username = Preferences.Get("username", "");
            try
            {
                var response = await client.GetAsync("http://10.0.2.2:52317/api/orders?username=" + username);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Item = JsonConvert.DeserializeObject<ObservableCollection<Order>>(content);
                    return Item;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return null;
        }
        public async Task<bool> Logout()
        {
            try
            {
                var access_token = Preferences.Get("access_token", "");
                
               var token_type =  Preferences.Get("token_type", "");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + access_token);
                var response = await client.PostAsync("http://10.0.2.2:61071/api/Account/Logout", null);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }


        }
    }
}
