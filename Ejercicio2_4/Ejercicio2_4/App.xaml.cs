using Ejercicio2_4.Controladores;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_4
{
    public partial class App : Application
    {
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


        static Database basedata;

        public static Database baseda
        {
            get
            {

                if (basedata == null)
                {
                    basedata = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbvideo.db3"));
                }
                return basedata;
            }
        }





    }
}
