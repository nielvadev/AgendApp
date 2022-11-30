using AgendApp.Model;
using Rg.Plugins.Popup.Services;
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


        public TasksViewModel(TaskModel selectedItem)
        {
            TaskName = selectedItem.TaskName;
            TaskDescription = selectedItem.TaskDescription;
            TaskDateI = selectedItem.TaskDateI;
            TaskDateF = selectedItem.TaskDateF;
            TaskPriority = selectedItem.TaskPriority;
            TaskStatus = selectedItem.TaskStatus;




        }
        #endregion

        #region PROPIEDADES
        public object ShowTasks
        {
            get { return _ShowTasks; }
            set { SetValue(ref _ShowTasks, value); }
        }

        public string _TaskName;
        public string TaskName
        {
            get { return _TaskName; }
            set { SetValue(ref _TaskName, value); }
        }

        public string _TaskDescription;
        public string TaskDescription
        {
            get { return _TaskDescription; }
            set { SetValue(ref _TaskDescription, value); }
        }

        public string _TaskDateI;
        public string TaskDateI
        {
            get { return _TaskDateI; }
            set { SetValue(ref _TaskDateI, value); }
        }

        public string _TaskDateF;
        public string TaskDateF
        {
            get { return _TaskDateF; }
            set { SetValue(ref _TaskDateF, value); }
        }

        public string _TaskPriority;
        public string TaskPriority
        {
            get { return _TaskPriority; }
            set { SetValue(ref _TaskPriority, value); }
        }

        public string _TaskStatus;
        public string TaskStatus
        {
            get { return _TaskStatus; }
            set { SetValue(ref _TaskStatus, value); }
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
        
        public async Task DeleteTaskAsync()
        {
            TaskModel task = new TaskModel();
            task.TaskName = TaskName;
            task.TaskDescription = TaskDescription;
            task.TaskDateI = TaskDateI;
            task.TaskDateF = TaskDateF;
            task.TaskPriority = TaskPriority;
            task.TaskStatus = TaskStatus;
            
            await App.Database.DeleteTaskAsync(task);
            await Application.Current.MainPage.DisplayAlert("Alerta", "Tarea eliminada", "OK");
            await Application.Current.MainPage.Navigation.PushAsync(new View.Tasks());
            await PopupNavigation.Instance.PopAsync(true);
            
        }
        
        public async Task UpdateTaskAsync()
        {
            TaskModel task = new TaskModel();
            task.TaskName = TaskName;
            task.TaskDescription = TaskDescription;
            task.TaskDateI = TaskDateI;
            task.TaskDateF = TaskDateF;
            task.TaskPriority = TaskPriority;
            task.TaskStatus = TaskStatus;

            await App.Database.UpdateTaskAsync(task);
            await Application.Current.MainPage.DisplayAlert("Actualizar", "Cambios guardados con éxito", "OK");
            await Application.Current.MainPage.Navigation.PushAsync(new View.Tasks());
            await PopupNavigation.Instance.PopAsync(true);
            
        }
        public async Task CompleteTaskAsync()
        {
            TaskModel task = new TaskModel();
            task.TaskName = TaskName;
            task.TaskDescription = TaskDescription;
            task.TaskDateI = TaskDateI;
            task.TaskDateF = TaskDateF;
            task.TaskPriority = TaskPriority;
            task.TaskStatus = "Completada";

            await App.Database.UpdateTaskAsync(task);
            await Application.Current.MainPage.DisplayAlert("Felicidades !", "Completaste tu tarea", "OK");
            await Application.Current.MainPage.Navigation.PushAsync(new View.Tasks());
            await PopupNavigation.Instance.PopAsync(true);
            
        }
        
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        //public ICommand ProcesoAsynCommand => new Command(async () => await ProcesoAsync());
        public ICommand DeleteTaskCommand => new Command(async () => await DeleteTaskAsync());
        public ICommand EditTaskCommand => new Command(async () => await UpdateTaskAsync());
        public ICommand CompleteTaskCommand => new Command(async () => await CompleteTaskAsync());
        public ICommand menuCommand => new Command(async () => await IrMenu());
        public ICommand newTaskCommand => new Command(async () => await irNewTask());
        //public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        //public ICommand deleteCommand => new Command(async () => await DeleteTask());


        #endregion
    }
}
