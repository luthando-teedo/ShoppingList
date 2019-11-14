using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaceOrder : ContentPage
    {
        public List<ClassProperties> tShirtOrder { get; set; }
        public PlaceOrder()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var tshirt = new ClassProperties();

            //BindingContext = tshirt;

            tShirtOrder = await App.Database.GetItemsAsync();
            BindingContext = tshirt;
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            /*    ClassProperties Properties = new ClassProperties()
                {
                    Name = Name_input.Text,
                    Gender = Gender_input.Text,
                    Size = shirtSize_input.Text,
                    Date = date_input.ToString(),
                    Color = ShirtColor_input.Text,
                    Address = address_input.Text
                };
                */

            var tshirt = BindingContext as ClassProperties;

            if (tshirt != null)
            {
                await App.Database.SaveItemAsync(tshirt);
               
                await Navigation.PushAsync(new Orderpage());

            }

           
         /* Name_input.Text = "";
            Gender_input.Text = "";
            shirtSize_input.Text = "";
            ShirtColor_input.Text = "";
            address_input.Text = "";
            */
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Name_input.Text = "";
            Gender_input.Text = "";
            shirtSize_input.Text = "";
            ShirtColor_input.Text = "";
            address_input.Text = "";
        }
    }
}