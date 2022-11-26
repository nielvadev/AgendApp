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
        string _Name;
        string _UserName;
        string _UserPassword;



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
            get { return _Name; }
            set { SetValue(ref this._Name, value); }
        }
        public string UsuarioTxt
        {
            get { return _UserName; }
            set { SetValue(ref this._UserName, value); }
        }
        public string PasswordTxt
        {
            get { return _UserPassword; }
            set { SetValue(ref this._UserPassword, value); }
        }

        #endregion

        #region PROCESOS
        public async Task NuevoRegistro()
        {
            UserModel user = new UserModel();
            user.Name = NombreTxt;
            user.UserName = UsuarioTxt;
            user.UserPassword = PasswordTxt;

            var exists = await App.Database.GetUser(user.UserName);

            if (exists == 0)
            {
                await App.Database.SaveUserModelAsync(user);
                await Application.Current.MainPage.DisplayAlert("Felicidades!", "Usuario Registrado con Éxito", "OK");
                await Navigation.PushAsync(new View.Login());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El usuario ya existe", "OK");
            }

            

            List<UserModel> ListUsers = new List<UserModel>();
            ListUsers = App.Database.GetUserModel().Result;
            

        }
        #endregion

        #region COMANDOS
        public ICommand RegistrarCommand => new Command(async () => await NuevoRegistro());
        #endregion
    }
}
