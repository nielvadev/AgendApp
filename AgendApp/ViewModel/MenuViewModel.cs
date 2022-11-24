using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AgendApp.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        #endregion

        #region CONSTRUCTOR
        public MenuViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region PROPIEDADES
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion

        #region COMANDOS
        public ICommand irPendientesCommand => new Command(async () => await Navigation.PushAsync(new View.Tasks()));
        public ICommand logOutCommand => new Command(async () => await Navigation.PushAsync(new View.Login()));

        #endregion
    }
}
