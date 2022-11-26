using AgendApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AgendApp.ViewModel
{
    public class NewTaskViewModel:BaseViewModel
    {
        #region VARIABLES
        string _TaskName;
        string _TaskDescription;
        string _TaskDateI = DateTime.Now.ToString("dd/MM/yyyy");
        string _TaskDateF = DateTime.Now.ToString("dd/MM/yyyy");
        string _TaskPriority = "1";
        string _TaskStatus = "Pendiente";
        #endregion

        #region CONSTRUCTOR
        public NewTaskViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region PROPIEDADES
        public string TaskName
        {
            get { return _TaskName; }
            set { SetValue(ref _TaskName, value); }
        }

        public string TaskDescription
        {
            get { return _TaskDescription; }
            set { SetValue(ref _TaskDescription, value); }
        }

        public string TaskDateI
        {
            get { return _TaskDateI; }
            set { SetValue(ref _TaskDateI, value); }
        }

        public string TaskDateF
        {
            get { return _TaskDateF; }
            set { SetValue(ref _TaskDateF, value); }
        }

        public string TaskPriority
        {
            get { return _TaskPriority; }
            set { SetValue(ref _TaskPriority, value); }
        }

        public string TaskStatus
        {
            get { return _TaskStatus; }
            set { SetValue(ref _TaskStatus, value); }
        }

        
        #endregion

        #region PROCESOS
        public async Task AddTask()
        {
            
            TaskModel task = new TaskModel();
            task.TaskName = TaskName;
            task.TaskDescription = TaskDescription;
            task.TaskDateI = TaskDateI;
            task.TaskDateF = TaskDateF;
            task.TaskPriority = TaskPriority;
            task.TaskStatus = TaskStatus;
            

            var exists = await App.Database.GetTask(task.TaskName);

            if (exists == 0)
            {
                await App.Database.SaveTaskModelAsync(task);
                await Application.Current.MainPage.DisplayAlert("Nuevo pendiente", "Insertado Exitosamente", "OK");
                await Navigation.PushAsync(new View.Tasks());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ya existe una tarea con este nombre", "OK");
            }


            

            List<TaskModel> ListTask= new List<TaskModel>();
            ListTask = App.Database.GetTaskModel().Result;




        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        public ICommand AddTaskCommand => new Command(async () => await AddTask());
        public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        #endregion
    }
}
