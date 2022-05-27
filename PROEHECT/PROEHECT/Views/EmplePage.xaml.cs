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

        private void btneliminar_Clicked(object sender, EventArgs e)
        {

        }
    }
}