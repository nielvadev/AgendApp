using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AgendApp.ViewModel
{
    public class PendingsViewModel:BaseViewModel
    {

        #region VARIABLES
        public object _ShowPendings;
        string _Texto;
        #endregion

        #region CONSTRUCTOR
        public object ShowPendings
        {
            get { return _ShowPendings; }
            set { SetValue(ref _ShowPendings, value); }
        }
        public PendingsViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GetPendings();
        }
        #endregion

        #region PROPIEDADES
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        
        public void GetPendings()
        {
            var query = "SELECT * FROM TaskModel WHERE TaskStatus = 'Pendiente'";
            var pendings = App.Database.QueryTaskModel(query).Result;

            if (pendings == null)
            {
                ShowPendings = "No hay Pendientes";
            }
            else
            {
                ShowPendings = pendings;
            }

        }
        #endregion

        #region PROCESOS
        public async Task IrMenu()
        {
            await Navigation.PushAsync(new View.Menu());
        }
        public async Task ProcesoAsync()
        {

        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        public ICommand ProcesoAsynCommand => new Command(async () => await ProcesoAsync());
        public ICommand menuCommand => new Command(async () => await IrMenu());
        public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        #endregion
    }
}
