using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendToServer : ContentPage
    {
        public SendToServer()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var url = "http://10.0.2.2:5000/products";
            var client = new HttpClient();
            var product = new Product
            {
                Name = "nelly (from webApp)",
                Gender = "female",
                Size = "medium",
                Color = "Dusty Pink",
                Address = "Century City",
                price = "R450",               
            };

            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(url, content);

                await DisplayAlert("Response Message", response.ReasonPhrase, "ok");
            }
            catch(Exception ex)
            {
                await DisplayAlert("Exception", ex.Message, "ok");
            }
        }
    }
}