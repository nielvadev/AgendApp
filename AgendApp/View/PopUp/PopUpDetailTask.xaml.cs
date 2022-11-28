using AgendApp.Model;
using AgendApp.ViewModel;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendApp.View.PopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpDetailTask
    {
        public PopUpDetailTask()
        {
            InitializeComponent();
        }

        public PopUpDetailTask(TaskModel selectedItem)
        {
            InitializeComponent();
            BindingContext = new TasksViewModel(selectedItem);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}