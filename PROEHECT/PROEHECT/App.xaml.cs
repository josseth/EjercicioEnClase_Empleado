using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PROEHECT.Controller;
using PROEHECT.Views;
using System.IO;

namespace PROEHECT
{
    public partial class App : Application
    {
        static DataBase db;

        public static DataBase DBase 
        { 
            get
            {
                if (db == null) {
                    db = new DataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Emple.db3"),"Empleado");
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new MainPage());
            //MainPage = new NavigationPage(new EmplePage());
            MainPage = new NavigationPage(new Main());
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
