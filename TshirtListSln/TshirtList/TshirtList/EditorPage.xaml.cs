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
    public partial class EditorPage : ContentPage
    {
        public ClassProperties tshirtOrders { get; set; }
        public EditorPage(ClassProperties product)
        {
            InitializeComponent();

            tshirtOrders = product;
            BindingContext = tshirtOrders;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //var stuff = App.Database;
            //tshirtOrders = await stuff.GetItemsAsync();
            //BindingContext = this;


        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            var SomethingToUpdate = tshirtOrders;
            await App.Database.SaveItemAsync(SomethingToUpdate);

            await Navigation.PushAsync(new Orderpage());
        }
    }
}