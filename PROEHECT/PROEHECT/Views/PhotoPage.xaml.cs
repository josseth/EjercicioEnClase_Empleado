using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;

namespace PROEHECT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoPage : ContentPage
    {
        public PhotoPage()
        {
            InitializeComponent();
        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            var foto = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Misfotos",
                Name = "IMG001.jpg",
                SaveToAlbum = true
            });
            await DisplayAlert("Path: ",foto.Path,"OK");
            if (foto != null) 
            {
                fillfoto.Source = ImageSource.FromStream(() =>
                  {
                      return foto.GetStream();
                  });
            }
        }
    }
}