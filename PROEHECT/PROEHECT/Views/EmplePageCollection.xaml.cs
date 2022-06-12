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
    public partial class EmplePageCollection : ContentPage
    {
        public EmplePageCollection()
        {
            InitializeComponent();
        }
        
        private void ListaEmple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ListaEmple.ItemsSource = await App.DBase.ObtenerListaEmple();
        }
    }
}