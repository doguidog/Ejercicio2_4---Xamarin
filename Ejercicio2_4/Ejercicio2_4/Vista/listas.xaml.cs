using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_4.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listas : ContentPage
    {
        public listas()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listav.ItemsSource = await App.baseda.listarvid();
        }

        Modelo.videorecord recor;
        private async void listav_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            recor = (Modelo.videorecord)e.Item;

            await Navigation.PushAsync(new videorepro(this.recor));
        }
    }
}