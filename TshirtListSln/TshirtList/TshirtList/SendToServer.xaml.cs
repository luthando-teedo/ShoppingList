using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendToServer : ContentPage
    {
        public List<ClassProperties> tShirtOrder { get; set; }
        public SendToServer()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var databaseContent = App.Database;
            tShirtOrder = await databaseContent.GetItemsAsync();

            var MyServerOrders = tShirtOrder.Select(x => new ClassProperties() { Name = x.Name,
                                                                                 Gender = x.Gender,
                                                                                 Size = x.Size,
                                                                                 Date = x.Date,
                                                                                 Color = x.Color,
                                                                                 Address = x.Address

                                                                                });
            
            //var product = new Product
            //{
            //    Name = "nelly (from webApp)",
            //    Gender = "female",
            //    Size = "medium",
            //    Color = "Dusty Pink",
            //    Address = "Century City",
            //    price = "R450",               
            //};

            var json = JsonConvert.SerializeObject(MyServerOrders);

            var client = new HttpClient();
            var url = "http://10.0.2.2:5000/products";
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