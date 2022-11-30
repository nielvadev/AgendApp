using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var url = button.ClassId;

            await Browser.OpenAsync(url);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var url = button.ClassId;

            await Browser.OpenAsync(url);
        }
    }
}