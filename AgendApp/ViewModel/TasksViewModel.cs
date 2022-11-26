using AgendApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AgendApp.ViewModel
{
    public class TasksViewModel:BaseViewModel
    {
        #region VARIABLES
        public object _ShowTasks;
        #endregion

        #region CONSTRUCTOR
        public TasksViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GetTasks();
        }

        #endregion

        #region PROPIEDADES
        public object ShowTasks
        {
            get { return _ShowTasks; }
            set { SetValue(ref _ShowTasks, value); }
        }
        #endregion
        
        #region PROCESOS
        public void GetTasks()
        {


            
            var tasks = App.Database.GetTaskAsync().Result;
            
            if (tasks == null)
            {
                ShowTasks = "No hay tareas";
            }
            else
            {
                ShowTasks = tasks;
            }

        }
        //public async Task ProcesoAsync()
        //{

        //}
        public async Task IrMenu()
        {
            await Navigation.PushAsync(new View.Menu());
        }

        public async Task irNewTask()
        {
            await Navigation.PushAsync(new View.NewTask());
        }

        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        //public ICommand ProcesoAsynCommand => new Command(async () => await ProcesoAsync());
        public ICommand menuCommand => new Command(async () => await IrMenu());
        public ICommand newTaskCommand => new Command(async () => await irNewTask());
        //public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        #endregion
    }
}
