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

        #region TABLES
        public DataBaseQuery(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UserModel>().Wait();
            _database.CreateTableAsync<TaskModel>().Wait();

        }
        #endregion

        #region CRUD
        public Task<int> SaveUserModelAsync(UserModel user)
        {
            return _database.InsertAsync(user);
        }
        public Task<List<UserModel>> GetUserModel()
        {
            return _database.Table<UserModel>().ToListAsync();
        }

        public Task<List<UserModel>> QueryUserModel(string query)
        {
            return _database.QueryAsync<UserModel>(query);
        }

        public Task<int> GetUser(string userName)
        {
            return _database.Table<UserModel>().Where(i => i.UserName == userName).CountAsync();
        }

        public Task<int> DeleteUserAsync(UserModel user)
        {
            return _database.DeleteAsync(user);
        }



        
        public Task<List<TaskModel>> GetTaskAsync()
        {
            {
                return _database.Table<TaskModel>().ToListAsync();
            }
        }





        public Task<int> SaveTaskModelAsync(TaskModel task)
        {
            return _database.InsertAsync(task);
        }
        public Task<List<TaskModel>> GetTaskModel()
        {
            return _database.Table<TaskModel>().ToListAsync();
        }

        public Task<int> GetTask(string taskName)
        {
            return _database.Table<TaskModel>().Where(i => i.TaskName == taskName).CountAsync();
        }

        public Task<List<TaskModel>> QueryTaskModel(string query)
        {
            return _database.QueryAsync<TaskModel>(query);
        }

        //public Task<TaskModel> GetTasksAsync(int id)
        //{
        //    return _database.Table<TaskModel>()
        //                    .Where(i => i.TaskID == id)
        //                    .FirstOrDefaultAsync();
        //}

        public Task<int> DeleteTaskAsync(TaskModel task)
        {
            return _database.DeleteAsync(task);
        }

















        //Generico
        //public Task<List<T>> GetTableModel<T>() where T : new()
        //{
        //    return _database.Table<T>().ToListAsync();
        //}

        //public Task<int> SaveModelAsync<T>(T model, bool isInsert) where T : new()
        //{
        //    if (isInsert != true)
        //    {
        //        return _database.UpdateAsync(model);
        //    }
        //    else
        //    {
        //        return _database.InsertAsync(model);
        //    }
        //}

        //public Task<int> DeleteModelAsync<T>(T model) where T : new()
        //{
        //    return _database.DeleteAsync(model);
        //}

        //public Task<List<T>> QueryModel<T>(string query) where T : new()
        //{
        //    return _database.QueryAsync<T>(query);
        //}

        #endregion

    }
}
