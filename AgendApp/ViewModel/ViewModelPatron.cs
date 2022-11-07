using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AgendApp.ViewModel
{
    internal class ViewModelPatron:BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        #endregion

        #region CONSTRUCTOR
        public ViewModelPatron(INavigation navigation)
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

        #region PROCESOS
        public async Task ProcesoAsync()
        {
            
        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        public ICommand ProcesoAsynCommand => new Command(async () => await ProcesoAsync());
        public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        #endregion
    }
}
