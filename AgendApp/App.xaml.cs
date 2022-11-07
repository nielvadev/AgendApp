using AgendApp.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AgendApp.DataBase;
using AgendApp.Model;
using System.IO;
using System.Collections.Generic;

namespace AgendApp
{
    public partial class App : Application
    {
        static DataBaseQuery database;

        public static DataBaseQuery Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataBaseQuery(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DbApp.db"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new Login());
        }

        protected override void OnStart()
        {
            /*UserModel user = new UserModel();
            user.Name = "Administrador";
            user.UserName = "admin";
            user.UserPassword = "1234";

            var result = App.Database.SaveUserModelAsync(user).Result;*/
            
            List<UserModel> ListUsers = new List<UserModel>();

            ListUsers = App.Database.GetUserModel().Result;


        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
