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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.ViewModels;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;

namespace TaskManager.Views
{
    /// <summary>
    /// Interaction logic for TaskManagerView.xaml
    /// </summary>
    public partial class TaskManagerView : UserControl
    {

        private ToDoListManagement ToDoListManagement;
        private TaskManagement taskManagement;
        public TaskManagerView()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();
            taskManagement = new TaskManagement((this.DataContext as MainWindowVM).CurrentToDoList);
            ToDoListManagement = new ToDoListManagement(ref (this.DataContext as MainWindowVM).vmlist);
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ToDoList selectedTdl = e.NewValue as ToDoList;
            if (selectedTdl != null)
            {
                MainWindowVM mainViewModel = DataContext as MainWindowVM;
                if (mainViewModel != null)
                {
                    mainViewModel.CurrentToDoList = selectedTdl;
                    taskManagement.ToDoList = mainViewModel.CurrentToDoList;
                }
            }
        }

        private void ListView_SelectItemChanged(object sender, SelectionChangedEventArgs args)
        {
            var selectedTask = (sender as ListBox).SelectedItem as Models.Task;
            if (selectedTask != null)
            {
                var mainViewModel = DataContext as MainWindowVM;
                if (mainViewModel != null)
                {
                    mainViewModel.CurrentTask = selectedTask;
                }
            }
        }

        private void Add_Task_ButtonClick(object sender, RoutedEventArgs e)
        {
            var addTaskView = new AddTaskView(taskManagement);
            addTaskView.Show();
        }

        private void Edit_Task_ButtonClick(object sender, RoutedEventArgs e)
        {
            var editTaskView = new EditTaskView((DataContext as MainWindowVM).CurrentTask);
            editTaskView.Show();
        }

        private void Delete_Task_ButtonClick(object sender, RoutedEventArgs e)
        {
            taskManagement.DeleteTask((DataContext as MainWindowVM).CurrentTask);
        }

        private void Set_Done_ButtonClick(object sender, RoutedEventArgs e)
        {
            taskManagement.SetDone((DataContext as MainWindowVM).CurrentTask);
        }

        private void Move_Up_Task_ButtonClick(object sender, RoutedEventArgs e)
        {
            taskManagement.MoveUp((DataContext as MainWindowVM).CurrentTask);
        }

        private void Move_Down_Task_ButtonClick(object sender, RoutedEventArgs e)
        {
            taskManagement.MoveDown((DataContext as MainWindowVM).CurrentTask);
        }

        private void PriorityHeader_Click(object sender, RoutedEventArgs e)
        {
            taskManagement.SortTasksByPriority();
        }

        private void DeadlineHeader_Click(object sender, RoutedEventArgs e)
        {
            taskManagement.SortTasksByDeadline();
        }

        private void Add_TDL_ButtonClick(object sender, RoutedEventArgs e)
        {
            ToDoListManagement.AddToDoList(new ToDoList { Name = "New TDL" });
        }

        private void Add_SubTDL_ButtonClick(object sender, RoutedEventArgs e)
        {
            ToDoListManagement.AddSubToDoList((DataContext as MainWindowVM).CurrentToDoList, new ToDoList { Name = "New TDL" });
        }

        private void Delete_TDL_ButtonClick(object sender, RoutedEventArgs e)
        {
            ToDoListManagement.RemoveToDoList(myTreeView.SelectedItem as ToDoList);
        }

        private void MoveUp_TDL_ButtonClick(object sender, RoutedEventArgs e)
        {
            ToDoListManagement.MoveUp(myTreeView.SelectedItem as ToDoList);
        }

        private void MoveDown_TDL_ButtonClick(object sender, RoutedEventArgs e)
        {
            ToDoListManagement.MoveDown(myTreeView.SelectedItem as ToDoList);
        }

        private void Archive_ButtonClick(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<ToDoList>));

            using (FileStream stream = new FileStream("todolist.xml", FileMode.Create))
            {
                serializer.Serialize(stream, (DataContext as MainWindowVM).VMList);
            }

            MessageBox.Show("Archive created!");
        }

        private void Open_ButtonClick(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<ToDoList>));

            using (FileStream stream = new FileStream("todolist.xml", FileMode.Open))
            {
                var list = serializer.Deserialize(stream) as ObservableCollection<ToDoList>;
                (DataContext as MainWindowVM).VMList = list;
                ToDoListManagement.ToDoLists = (DataContext as MainWindowVM).VMList;
            }

            MessageBox.Show("Archive opened!");
        }

        bool statState = false;
        private void Stats_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (!statState)
            {
                taskToday.Visibility = Visibility.Visible;
                taskTmr.Visibility = Visibility.Visible;
                taskTB.Visibility = Visibility.Visible;
                taskOvr.Visibility = Visibility.Visible;
                taskCom.Visibility = Visibility.Visible;
                statState = true;
            }
            else
            {
                taskToday.Visibility = Visibility.Hidden;
                taskTmr.Visibility = Visibility.Hidden;
                taskTB.Visibility = Visibility.Hidden;
                taskOvr.Visibility = Visibility.Hidden;
                taskCom.Visibility = Visibility.Hidden;
                statState = false;
            }

            (DataContext as MainWindowVM).UpdateStats();
        }

        
    }
}
