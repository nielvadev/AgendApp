using AgendApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AgendApp.View.PopUp;
using AgendApp.Model;

namespace AgendApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tasks : ContentPage
    {
        public Tasks()
        {
            InitializeComponent();
            BindingContext = new TasksViewModel(Navigation);
        }

        private void ListTasksView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopUpDetailTask(e.SelectedItem as TaskModel));
        }
    }
}