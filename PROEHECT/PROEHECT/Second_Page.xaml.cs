using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PROEHECT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Second_Page : ContentPage
    {
        public Second_Page()
        {
            InitializeComponent();
        }
        public Second_Page(String nom,String edad)
        {
            InitializeComponent();
            lblnombre.Text = nom;
            lbledad.Text = edad;
        }
    }
}