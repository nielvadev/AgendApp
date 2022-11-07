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
            await DisplayAlert("Registro", "Prueba Registro", "OK");
        }
        #endregion

        #region COMANDOS
        public ICommand RegistrarCommand => new Command(async () => await NuevoRegistro());
        #endregion
    }
}
