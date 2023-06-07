using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ViewModels
{
    internal class AddTaskVM
    {
        public Models.Task Task { get; set; }

        public AddTaskVM(Models.Task task)
        {
            this.Task = task;
        }
    }
}
