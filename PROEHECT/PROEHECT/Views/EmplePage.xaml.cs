using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PROEHECT.Models;
using PROEHECT.Controller;

namespace PROEHECT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmplePage : ContentPage
    {
        public EmplePage()
        {
            InitializeComponent();
        }

        private async void btngregar_Clicked(object sender, EventArgs e)
        {
            var emple = new Empleado
            {
                id = 0,
                nombre = txtnombre.Text,
                edad = txtedad.Text,
                genero = genero.SelectedItem.ToString(),
                fechaingreso = fecha.Date.ToString()
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
    }
}