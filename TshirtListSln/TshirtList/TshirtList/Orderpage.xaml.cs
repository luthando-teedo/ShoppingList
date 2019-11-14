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
    public partial class Orderpage : ContentPage
    {
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

        //private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
            
        //   var result = await DisplayAlert("Hi Customer", "Do you want to Delete?", "Yes", "No");

        //    if (result)
        //    {
        //          //DELETE STUFF
        //    }
 
        //}

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var result = await DisplayAlert("Hi Customer", "Do you want to Delete?", "Yes", "No");

            if (result)
            {
                //DELETE STUFF

                var tshirtorders = e.Item as ClassProperties;
                //var stuffs = tshirtorders.ID;
            }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SendToServer());
        }
    }
}