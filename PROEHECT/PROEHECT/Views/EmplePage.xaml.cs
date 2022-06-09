using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PROEHECT.Models;
using PROEHECT.Controller;
using Plugin.Media;
using System.IO;
using Xamarin.Essentials;

namespace PROEHECT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmplePage : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile filefoto = null;
        public EmplePage()
        {
            InitializeComponent();
        }
        private Byte[] converttobytearray() 
        {
            if (filefoto != null)
            {
                using (MemoryStream mem = new MemoryStream())
                {
                    Stream stream = filefoto.GetStream();
                    stream.CopyTo(mem);
                    return mem.ToArray();
                }
            }
            else 
            {
                return null;
            }
        }
        private async void btngregar_Clicked(object sender, EventArgs e)
        {
            if (filefoto == null)
            {
                await DisplayAlert("Error", "No se encontro la foto!", "OK");
                return;
            }
            var emple = new Empleado
            {
                id = 0,
                nombre = txtnombre.Text,
                edad = txtedad.Text,
                genero = genero.SelectedItem.ToString(),
                fechaingreso = fecha.Date.ToString(),
                foto = converttobytearray()
            };
            var result = await App.DBase.EmpleSave(emple);
            if (result > 0)
            {
                await DisplayAlert("INFO", "Empleado Ingresado", "OK");
            }
            else {
                await DisplayAlert("ALERTA", "Empleado NO INGRESADO", "NO");
            }
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var latlog = await Geolocation.GetLocationAsync();
        }
        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            var emple = new Empleado
            {
                id = Convert.ToInt32(txtid.Text),
                nombre = txtnombre.Text,
                edad = txtedad.Text,
                genero = genero.SelectedItem.ToString(),
                fechaingreso = fecha.Date.ToString()
            };
            if (txtid.Text != null || txtid.Text.Length==0)
            {
                var result = await App.DBase.BorrarEmple(emple);
                if (result != 0) { await DisplayAlert("Aviso", "Persona Eliminada con Exito!!!", "Ok"); }
                else { await DisplayAlert("Aviso", "Ha Ocurrido un Error", "Ok"); }
            }
            else
            {
                await DisplayAlert("Aviso", "Ha Ocurrido un Error", "Ok");
            }

            await Navigation.PopAsync();
        }

        private async void btnactualiza_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtid.Text))
            {
                var emple = new Empleado
                {
                    id = Convert.ToInt32(txtid.Text),
                    nombre = txtnombre.Text,
                    edad = txtedad.Text,
                    genero = genero.SelectedItem.ToString(),
                    fechaingreso = fecha.Date.ToString()
                };
                var result = await App.DBase.EmpleSave(emple);
                if (result != 0)
                {
                    await DisplayAlert("Aviso", "Persona Actualizada con Exito!!!", "Ok");
                }
                else
                {
                    await DisplayAlert("Aviso", "Ha Ocurrido un Error", "Ok");
                }

                await Navigation.PopAsync();
            }
        }

        private async void takefoto_Clicked(object sender, EventArgs e)
        {
            //VIENE ESTE CODIGO DE PHOYOPAGE
            filefoto = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Misfotos",
                Name = "IMG001.jpg",
                SaveToAlbum = true
            });
            await DisplayAlert("Path: ", filefoto.Path, "OK");
            if (filefoto != null)
            {
                fotoo.Source = ImageSource.FromStream(() =>
                {
                    return filefoto.GetStream();
                });
            }
        }
    }
}