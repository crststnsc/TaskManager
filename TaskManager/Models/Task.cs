using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaskManager.Models
{
    public enum TaskStatus
    {
        Created,
        InProgress,
        Done
    }

    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }

    public enum TaskCategory
    {
        Work,
        School,
        Other
    }

    public class Task : TreeNode
    {
        [XmlIgnore]
        public string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        [XmlIgnore]
        public TaskPriority priority;
        public TaskPriority Priority
        {
            get { return priority; }
            set
            {
                priority = value;
                OnPropertyChanged(nameof(Priority));
            }
        }
        [XmlIgnore]
        public TaskStatus status;
        public TaskStatus Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        [XmlIgnore]
        public DateTime deadline;
        public DateTime TaskDeadline
        {
            get { return deadline; }
            set
            {
                deadline = value;
                OnPropertyChanged(nameof(TaskDeadline));
            }
        }
        [XmlIgnore]
        public DateTime dateofcompletion;
        public DateTime TaskDateOfCompletion
        {
            get { return dateofcompletion; }
            set
            {
                dateofcompletion = value;
                OnPropertyChanged(nameof(TaskDateOfCompletion));
            }
        }
        [XmlIgnore]
        public TaskCategory category;
        public TaskCategory TaskCategory
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged(nameof(TaskCategory));
            }
        }

        public Task() : base()
        {
            priority = TaskPriority.Low;
            status = TaskStatus.Created;
            category = TaskCategory.Other;
        }

    }
}
