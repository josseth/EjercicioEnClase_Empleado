using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PROEHECT
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage(DateTime date)
        {
            InitializeComponent();
        }

        private async void btnmostrar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("INFO","Nombre: "+txtnombre.Text+"\nEdad: "+txtedad.Text,"OK");
            txtnombre.Text="";
            txtedad.Text = "";
        }

        private async void btnpagina2_Clicked(object sender, EventArgs e)
        {
            var emple = new Models.Empleado
            {
                nombre=txtnombre.Text,
                edad=txtedad.Text
            };

            //METODO CON 1 OBJETO
            //var segundaP = new Second_Page();
            //segundaP.BindingContext = emple;
            //await Navigation.PushAsync(segundaP);

            //METODO SIN PARAMETROS
            //await Navigation.PushAsync(new Second_Page());

            //METODO CON COSNTRUCTOR
            await Navigation.PushAsync(new Second_Page(txtnombre.Text,txtedad.Text));
        }
    }
}
