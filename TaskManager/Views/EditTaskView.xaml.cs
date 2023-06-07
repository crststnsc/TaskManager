using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.ViewModels;

namespace TaskManager.Views
{
    /// <summary>
    /// Interaction logic for EditTaskView.xaml
    /// </summary>
    public partial class EditTaskView : Window
    {
        public Models.Task task;

        public EditTaskView(Models.Task task)
        {
            InitializeComponent();
            this.task = task;
            DataContext = task;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Models.TaskPriority priority = new TaskPriority();
            Models.TaskCategory category = new TaskCategory();
            Models.TaskStatus status = new Models.TaskStatus();

            switch (Priority.Text)
            {
                case "Low":
                    priority = Models.TaskPriority.Low;
                    break;
                case "Medium":
                    priority = Models.TaskPriority.Medium;
                    break;
                case "High":
                    priority = Models.TaskPriority.High;
                    break;
            }

            switch (Status.Text)
            {
                case "Created":
                    status = Models.TaskStatus.Created;
                    break;
                case "In Progress":
                    status = Models.TaskStatus.InProgress;
                    break;
                case "Done":
                    status = Models.TaskStatus.Done;
                    break;
            }

            switch (Category.Text)
            {
                case "Work":
                    category = TaskCategory.Work; break;
                case "School":
                    category = TaskCategory.School; break;
                case "Other":
                    category = TaskCategory.Other; break;
            }

            task.Name = TaskName.Text;
            task.Status = status;
            task.TaskCategory = category;
            task.dateofcompletion = DoC.SelectedDate ?? DateTime.Now;
            task.TaskDeadline = Deadline.SelectedDate ?? DateTime.Now;
            task.Priority = priority;
            task.description = Description.Text;
        }
    }
}
