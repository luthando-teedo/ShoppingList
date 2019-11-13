using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtList
{
    public partial class App : Application
    {
        static functionalityClass database;
        public App()
        {

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.OrangeRed,
                BarTextColor = Color.White
            };
        }

        public static functionalityClass Database
        {
            get
            {
                if(database == null)
                {
                    database = new functionalityClass(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "T_shirtlistSQLite.db3"));
                }

                return database;
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
