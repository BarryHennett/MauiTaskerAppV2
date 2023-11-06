using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using PropertyChanged;

namespace TaskApp.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Category
    {
        public string CategoryName { get; set; }
        public int PendingTasks { get; set; }
        public float Percentage { get; set; }
        public bool IsSelected { get; set; }
        public string Color { get; set; }
        public int Id { get; set; }


        public ObservableCollection<MyTask> Tasks { get; set; }

        //this is the total amount of tasks

        private int totalTasks;

        public int TotalTasks
        {
            get { return totalTasks; }
            set
            {
                if (totalTasks != value)
                {
                    totalTasks = value;
                }
            }
        }
        public Category()
        {
            Tasks = new ObservableCollection<MyTask>();
            UpdateTotalTasks();
        }

        //this is my add task feature
        public void AddTask(MyTask task)
        {
            Tasks.Add(task);
            UpdateTotalTasks();
        }

        //here the tasks are being updated
        public void UpdateTotalTasks()
        {
            TotalTasks = Tasks.Count;
        }
    }
}
