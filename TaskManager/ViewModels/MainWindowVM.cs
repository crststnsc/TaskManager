using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ObservableCollection<ToDoList> vmlist;
        public ObservableCollection<ToDoList> VMList
        {
            get { return vmlist; }
            set
            {
                vmlist = value;
                OnPropertyChanged(nameof(VMList));
            }
        }

        public ToDoList SelectedList;
        public Models.Task SelectedTask;

        public ICommand command { get; set; } = new RelayCommand(() => MessageBox.Show("Proiect Realizat de Stanescu Cristian"));
        public ICommand exitCommand { get; set; } = new RelayCommand(() => Application.Current.Shutdown());  

        public MainWindowVM()
        {
            VMList = new ObservableCollection<ToDoList>();
            SelectedList = new ToDoList();
            SelectedTask = new Models.Task();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ToDoList CurrentToDoList
        {
            get { return SelectedList; }
            set
            {

                SelectedList = value;
                OnPropertyChanged(nameof(CurrentToDoList));

            }
        }

        public Models.Task CurrentTask
        {
            get { return SelectedTask; }
            set
            {

                SelectedTask = value;
                OnPropertyChanged(nameof(CurrentTask));

            }
        }

        public void Update(string name)
        {
            OnPropertyChanged(name);
        }

        private string _tasksToday;
        public string TasksDueToday
        {
            get { return _tasksToday; }
            set
            {
                _tasksToday = value;
                OnPropertyChanged(nameof(TasksDueToday));
            }
        }

        private string _tasksTomorrow;
        public string TasksDueTomorrow
        {
            get { return _tasksTomorrow; }
            set
            {
                _tasksTomorrow = value;
                OnPropertyChanged(nameof(TasksDueTomorrow));
            }
        }

        private string _tasksOverdue;
        public string TasksOverdue
        {
            get { return _tasksOverdue; }
            set
            {
                _tasksOverdue = value;
                OnPropertyChanged(nameof(TasksOverdue));
            }
        }

        private string _tasksCompleted;
        public string TasksCompleted
        {
            get { return _tasksCompleted; }
            set
            {
                _tasksCompleted = value;
                OnPropertyChanged(nameof(TasksCompleted));
            }
        }

        private string _tasksToBeCompleted;
        public string TasksToBeCompleted
        {
            get { return _tasksToBeCompleted;}
            set
            {
                _tasksToBeCompleted = value;
                OnPropertyChanged(nameof(TasksToBeCompleted));
            }
        }

        public void UpdateStats()
        {
            int today = 0;
            int tomorrow = 0;
            int overdue = 0;
            int completed = 0;
            int tobecompleted = 0;

            foreach (ToDoList list in VMList)
            {
                foreach (Models.Task task in list.TaskList)
                {
                    if (task.TaskDeadline == DateTime.Today)
                    {
                        today++;
                    }
                    else if (task.TaskDeadline == DateTime.Today.AddDays(1))
                    {
                        tomorrow++;
                    }
                    else if (task.TaskDeadline < DateTime.Today)
                    {
                        overdue++;
                    }
                    else if (task.Status == Models.TaskStatus.Done)
                    {
                        completed++;
                    }
                    else
                    {
                        tobecompleted++;
                    }
                }
            }
            TasksDueToday = today.ToString();
            TasksDueTomorrow = tomorrow.ToString();
            TasksOverdue = overdue.ToString();
            TasksCompleted = completed.ToString();
            TasksToBeCompleted = tobecompleted.ToString();

            Debug.WriteLine("Tasks due today: " + TasksDueToday);
        }

    }
}
