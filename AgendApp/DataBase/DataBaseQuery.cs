using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AgendApp.Model;
using SQLite;

namespace AgendApp.DataBase
{
    public class DataBaseQuery
    {
        readonly SQLiteAsyncConnection _database;

        public DataBaseQuery(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UserModel>().Wait();
        }

        #region CRUD
        public Task<int> SaveUserModelAsync(UserModel user)
        {
            if (user.UserID != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }
        public Task<List<UserModel>> GetUserModel()
        {
            return _database.Table<UserModel>().ToListAsync();
        }

        public Task<List<UserModel>> QueryUserModel(string query)
        {
            return _database.QueryAsync<UserModel>(query);
        }

        public Task<UserModel> GetUsersAsync(int id)
        {
            return _database.Table<UserModel>()
                            .Where(i => i.UserID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> DeleteUserAsync(UserModel user)
        {
            return _database.DeleteAsync(user);
        }
        #endregion
    }
}
