using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AgendApp.ViewModel
{
    public class CompletedViewModel:BaseViewModel
    {

        #region VARIABLES
        public object _ShowCompleted;
        string _Texto;
        #endregion

        #region CONSTRUCTOR
        public object ShowCompleted
        {
            get { return _ShowCompleted; }
            set { SetValue(ref _ShowCompleted, value); }
        }
        public CompletedViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GetCompleted();
        }
        #endregion

        #region PROPIEDADES
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }

        public void GetCompleted()
        {
            var query = "SELECT * FROM TaskModel WHERE TaskStatus = 'Completada'";
            var completed = App.Database.QueryTaskModel(query).Result;

            if (completed == null)
            {
                ShowCompleted = "No hay Tareas completadas";
            }
            else
            {
                ShowCompleted = completed;
            }

        }
        #endregion

        #region PROCESOS
        public async Task IrMenu()
        {
            await Navigation.PushAsync(new View.Menu());
        }

        #endregion

        #region COMANDOS
        public ICommand menuCommand => new Command(async () => await IrMenu());
        #endregion
    }
}
