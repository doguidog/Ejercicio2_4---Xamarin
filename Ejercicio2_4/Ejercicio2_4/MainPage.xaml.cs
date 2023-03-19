using Ejercicio2_4.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xam.Forms.VideoPlayer;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ejercicio2_4
{
    public partial class MainPage : ContentPage
    {
        public string Photo;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGrabar_Clicked(object sender, EventArgs e)
        {
            var status = await Permissions.RequestAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                return; // si no tiene los permisos no avanza
            }

            grabar();
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtdescripcion.Text))
            {
                await DisplayAlert("Aviso", "Descripcion Vacia", "OK");
                txtdescripcion.Focus();
            }
            else
            {
                var videos = new Modelo.videorecord
                {
                    uri = Photo,
                    descripcion = txtdescripcion.Text
                };

                var resultado = await App.baseda.Guardar(videos);

                if (resultado == 1)
                {
                    await DisplayAlert("", "Video Guardado", "OK");
                    txtdescripcion.Text = "";
                    video.Source = null;
                }
                else
                {
                    await DisplayAlert("Error", "Error al guardar video", "OK");
                }
            }
        }

        public async void grabar()
        {
            try
            {
                var photo = await MediaPicker.CaptureVideoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {Photo}");

                UriVideoSource uriVideoSurce = new UriVideoSource()
                {
                    Uri = Photo
                };

                video.Source = uriVideoSurce;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            if (photo == null)
            {
                Photo = null;
                return;
            }

            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);
            Photo = newFile;
        }

        private async void btnSalvar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtdescripcion.Text))
            {
                await DisplayAlert("Aviso", "Descripcion Vacia", "OK");
                txtdescripcion.Focus();
            }
            else
            {
                var videos = new Modelo.videorecord
                {
                    uri = Photo,
                    descripcion = txtdescripcion.Text
                };

                var resultado = await App.baseda.Guardar(videos);

                if (resultado == 1)
                {
                    await DisplayAlert("", "Video Guardado", "OK");
                    txtdescripcion.Text = "";
                    video.Source = null;
                }
                else
                {
                    await DisplayAlert("Error", "Error al guardar video", "OK");
                }
            }
        }

       /* private async void btnlistar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new listas());
        }*/

        private async void btnlistarvideo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new listas());
        }
    }
}
