using AgendApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AgendApp.ViewModel
{
    public class RegistroViewModel:BaseViewModel
    {
        #region VARIABLES
        string nombre;
        string usuario;
        string password;

        
        #endregion

        #region CONSTRUCTOR
        public RegistroViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region PROPIEDADES
        public string NombreTxt
        {
            get { return nombre; }
            set { SetValue(ref this.nombre, value); }
        }
        public string UsuarioTxt
        {
            get { return usuario; }
            set { SetValue(ref this.usuario, value); }
        }
        public string PasswordTxt
        {
            get { return password; }
            set { SetValue(ref this.password, value); }
        }

        #endregion

        #region PROCESOS
        public async Task NuevoRegistro()
        {
            UserModel user = new UserModel();
            user.Name = NombreTxt;
            user.UserName = UsuarioTxt;
            user.UserPassword = PasswordTxt;

            var result = App.Database.SaveUserModelAsync(user).Result;

            List<UserModel> ListUsers = new List<UserModel>();

            ListUsers = App.Database.GetUserModel().Result;
            if (result == 1)
            {
                await DisplayAlert("Registro", UsuarioTxt + " Se ha registrado Exitosamente", "OK");
            }
            else
            {
                await DisplayAlert("Registro", "El usuario ya existe", "OK");
            }

        }
        #endregion

        #region COMANDOS
        public ICommand RegistrarCommand => new Command(async () => await NuevoRegistro());
        #endregion
    }
}
