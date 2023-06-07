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
    /// Interaction logic for AddTaskView.xaml
    /// </summary>
    public partial class AddTaskView : Window
    {
        private TaskManagement taskManagement;

        public AddTaskView(TaskManagement taskManagement)
        {
            InitializeComponent();
            this.taskManagement = taskManagement;
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

            DateTime deadline = Deadline.SelectedDate.HasValue ? Deadline.SelectedDate.Value : DateTime.Now;
            DateTime doc = DoC.SelectedDate.HasValue ? DoC.SelectedDate.Value : DateTime.Now;

            Models.Task task = new Models.Task
            {
                Name = TaskName.Text,
                Priority = priority,
                Status = status,
                TaskCategory = category,
                TaskDeadline = deadline,
                TaskDateOfCompletion = doc,
                Description = Description.Text
            };

            taskManagement.AddTask(task);
        }
    }
}
