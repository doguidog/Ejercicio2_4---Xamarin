using Ejercicio2_4.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Forms.VideoPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_4.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class videorepro : ContentPage
    {
        public videorepro(videorecord recor)
        {
            InitializeComponent();
            datos(recor);
        }

        private void datos(videorecord video)
        {
            lbldescripcion.Text = video.descripcion;
            UriVideoSource uriVideoSurce = new UriVideoSource()
            {
                Uri = video.uri
            };
            recor.Source = uriVideoSurce;
        }

        private async void btnatras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}