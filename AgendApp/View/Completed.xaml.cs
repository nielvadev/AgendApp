using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Completed : ContentPage
    {
        public Completed()
        {
            InitializeComponent();
            BindingContext = new ViewModel.CompletedViewModel(Navigation);
        }
    }
}