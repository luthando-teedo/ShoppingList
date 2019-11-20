using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Orderpage : ContentPage
    {
        public List<ClassProperties> tShirtOrder { get; set; }
        public IList<ClassProperties> tshirtOrders { get; set; }
        public Orderpage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var stuff = App.Database;
            tshirtOrders = await stuff.GetItemsAsync();
            BindingContext = this;

            
        }

        //DELETING WHATEVER YOU TAPPED ON
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var result = await DisplayAlert($"Hellow There!", "Do you want to Delete?", "Yes", "No");

            if (result)
            {
                //DELETE STUFF

                var tshirtOrder = e.Item as ClassProperties;
                await App.Database.DeleteItemAsync(tshirtOrder);

                await Navigation.PushAsync(new Orderpage());
            }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                await DisplayAlert("Connection", "Internet is working", "ok");
            }
            var databaseContent = App.Database;
            tShirtOrder = await databaseContent.GetItemsAsync();

            var MyServerOrders = tShirtOrder.Select(x => new ClassProperties()
            {
                Name = x.Name,
                Gender = x.Gender,
                Size = x.Size,
                Date = x.Date,
                Color = x.Color,
                Address = x.Address

            });

            var json = JsonConvert.SerializeObject(MyServerOrders);

            var client = new HttpClient();
            var url = "http://10.0.2.2:5000/products";
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(url, content);

                await DisplayAlert("Response Message", response.ReasonPhrase, "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception", ex.Message, "ok");
            }
            //await Navigation.PushAsync(new SendToServer());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlaceOrder());
        }
    }
}