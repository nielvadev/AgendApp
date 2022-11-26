using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendApp.Model
{
    public class TaskModel
    {

        [Unique, PrimaryKey, MaxLength(20)]
        public string TaskName { get; set; }
        [MaxLength(30)]
        public string TaskDescription { get; set; }
        [MaxLength(100)]
        public string TaskDateI { get; set; }
        [MaxLength(30)]
        public string TaskDateF { get; set; }
        [MaxLength(1)]
        public string TaskPriority { get; set; }
        [MaxLength(10)]
        public string TaskStatus { get; set; }
    }
}
