using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AgendApp.Model
{
    public class UserModel
    {

        [PrimaryKey, Unique, MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string UserName { get; set; }
        [MaxLength(10)]
        public string UserPassword { get; set; }
    }
}
