using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using  System.IO;
using CRUD.Views;

namespace CRUD
{
    public partial class App : Application
    {
        private static ContactDatabaseService db;
        public static ContactDatabaseService MyDB
        {
            get
            {
                if (db == null)
                {
                    db = new ContactDatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "contacts.db3"));
                }
                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
