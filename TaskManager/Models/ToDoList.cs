using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace TaskManager.Models
{
    public class ToDoList : TreeNode
    {
        public ToDoList() : base()
        {
            TaskList = new ObservableCollection<Task>();
            ToDoLists = new ObservableCollection<ToDoList>();
        }
        [XmlIgnore]
        public BitmapSource imagesource;
        public BitmapSource ImageSource
        {
            get { return imagesource; }
            set
            {
                imagesource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }
        [XmlIgnore]
        public ObservableCollection<Task> tasklist;
        public ObservableCollection<Task> TaskList
        {
            get { return tasklist; }
            set
            {
                tasklist = value;
                OnPropertyChanged(nameof(TaskList));
            }
        }
        [XmlIgnore]
        public ObservableCollection<ToDoList> todolists;
        public ObservableCollection<ToDoList> ToDoLists
        {
            get { return todolists; }
            set
            {
                todolists = value;
                OnPropertyChanged(nameof(ToDoLists));
            }
        }
    }
}
