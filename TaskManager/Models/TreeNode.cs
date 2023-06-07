using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaskManager.Models
{
    public class TreeNode : INotifyPropertyChanged
    {
        [XmlIgnore]
        public string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        [XmlIgnore]
        public ObservableCollection<TreeNode> children;
        public ObservableCollection<TreeNode> Children
        {
            get { return children; }
            set { children = value; OnPropertyChanged(nameof(Children)); }
        }

        public TreeNode()
        {
            Children = new ObservableCollection<TreeNode>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
