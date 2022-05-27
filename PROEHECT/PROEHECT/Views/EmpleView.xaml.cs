using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PROEHECT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpleView : ContentPage
    {
        public EmpleView()
        {
            InitializeComponent();
        }
        public EmpleView(int id,String nombre,String edad,String genero,String fecha)
        {
            InitializeComponent();
            lblid.Text = "" + id;
            lblname.Text = nombre;
            lbledad.Text = edad;
            lblgen.Text = genero;
            lblfecha.Text = fecha;
        }
    }
}