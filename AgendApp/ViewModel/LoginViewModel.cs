using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;
using AgendApp.Model;

namespace AgendApp.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {
        #region VARIABLES
        string nombre;
        string usuario;
        string password;
        
        #endregion

        #region CONSTRUCTOR
        public LoginViewModel(INavigation navigation)
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
        public async Task IrRegistrar()
        {
            await Navigation.PushAsync(new Views.Registro());
        }


        public async Task LoginMethod()
        {
            string _query = "SELECT * FROM UserModel WHERE UserName = '" + UsuarioTxt + "' AND UserPassword = '" + PasswordTxt + "'";
            List<UserModel> ListUsers = App.Database.QueryUserModel(_query).Result;

            if (ListUsers.Count > 0)
            {
                await DisplayAlert("Login", "Bienvenido", "OK"); 
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
            }
        }
#endregion

        #region COMANDOS
        public ICommand LoginCommand => new Command(async () => await LoginMethod());
        public ICommand IrRegistrarCommand => new Command(async () => await IrRegistrar());
        #endregion
    }
}

