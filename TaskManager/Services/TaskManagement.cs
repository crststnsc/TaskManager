using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskManagement : INotifyPropertyChanged
    {
        public ToDoList todolist;
        public ToDoList ToDoList
        {
            get { return todolist; }
            set
            {
                todolist = value;
                OnPropertyChanged(nameof(ToDoList));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddTask(Models.Task task)
        {
            this.ToDoList.TaskList.Add(task);
            ToDoList.Children.Add(task);
            OnPropertyChanged(nameof(ToDoList));
        }

        public void DeleteTask(Models.Task task)
        {
            this.ToDoList.TaskList.Remove(task);
            ToDoList.Children.Remove(task);
        }

        public TaskManagement(ToDoList toDoList)
        {
            this.ToDoList = toDoList;
        }

        public void SetDone(Models.Task task)
        {
            task.Status = Models.TaskStatus.Done;
        }

        public void MoveUp(Models.Task task)
        {
            int index = ToDoList.TaskList.IndexOf(task);
            if (index > 0)
            {
                ToDoList.TaskList.Remove(task);
                ToDoList.TaskList.Insert(index - 1, task);
            }
        }

        public void MoveDown(Models.Task task)
        {
            int index = ToDoList.TaskList.IndexOf(task);
            if (index < ToDoList.TaskList.Count - 1)
            {
                ToDoList.TaskList.Remove(task);
                ToDoList.TaskList.Insert(index + 1, task);
            }
        }

        bool sortProperty = false;
        public void SortTasksByPriority()
        {
            if (sortProperty)
            {
                //ToDoList.TaskList = ToDoList.TaskList.OrderBy(task => task.Priority).ToList();
                sortProperty = false;

            }
            else
            {
                //ToDoList.TaskList = ToDoList.TaskList.OrderByDescending(task => task.Priority).ToList();
                sortProperty = true;
            }
        }

        bool sortDeadline = false;
        public void SortTasksByDeadline()
        {
            if (sortDeadline)
            {
                //ToDoList.TaskList = ToDoList.TaskList.OrderBy(task => task.TaskDeadline);
                sortDeadline = false;
            }
            else
            {
                //ToDoList.TaskList = ToDoList.TaskList.OrderByDescending(task => task.TaskDeadline);
                sortDeadline = true;
            }
        }
    }
}
