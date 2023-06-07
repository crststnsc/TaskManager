using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using TaskManager.Models;

namespace TaskManager.Services
{
    internal class ToDoListManagement : INotifyPropertyChanged
    {
        public ObservableCollection<ToDoList> todolists;
        public ObservableCollection<ToDoList> ToDoLists
        {
            get { return todolists; }
            set
            {
                todolists = value;
                OnPropertyChanged("ToDoLists");
            }
        }
        public ToDoListManagement(ref ObservableCollection<ToDoList> toDoLists)
        {
            this.ToDoLists = toDoLists;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddToDoList(ToDoList toDoList)
        {
            this.ToDoLists.Add(toDoList);
        }

        public void AddSubToDoList(ToDoList toDoList, ToDoList subToDoList)
        {
            toDoList.ToDoLists.Add(subToDoList); 
            toDoList.Children.Add(subToDoList);
        }

        public void RemoveToDoList(ToDoList toDoList)
        {
            this.ToDoLists.Remove(toDoList);
            OnPropertyChanged(nameof(ToDoLists));
        }

        public void MoveUp(ToDoList list)
        {
            int index = ToDoLists.IndexOf(list);
            if (index > 0)
            {
                ToDoLists.Remove(list);
                ToDoLists.Insert(index - 1, list);
                OnPropertyChanged("ToDoList");
            }
        }

        public void MoveDown(ToDoList list)
        {
            int index = ToDoLists.IndexOf(list);
            if (index > 0)
            {
                ToDoLists.Remove(list);
                ToDoLists.Insert(index + 1, list);
                OnPropertyChanged("ToDoList");
            }
        }
    }
}
