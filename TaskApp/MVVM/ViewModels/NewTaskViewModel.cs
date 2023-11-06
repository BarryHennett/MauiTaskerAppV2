using System.Collections.ObjectModel;
using TaskApp.MVVM.Models;
using PropertyChanged;
using System;

public class NewTaskViewModel
{
    public event EventHandler<TaskAddedEventArgs> TaskAdded;

    public string Task { get; set; }
    public ObservableCollection<MyTask> Tasks { get; set; }
    public ObservableCollection<Category> Categories { get; set; }
    public Category SelectedCategory { get; set; }

    public NewTaskViewModel()
        //here is the colors for the category tasks
    {
        Categories = new ObservableCollection<Category>()
        {
            new Category
            {
                Id = 1,
                CategoryName = "Cleaning",
                Color = "#84B94A"
            },
            new Category
            {
                Id = 2,
                CategoryName = "Work/Uni",
                Color = "#E09735"
            },
            new Category
            {
                Id = 3,
                CategoryName = "Groceries",
                Color = "#D935E0"
            }
        };

        //here i am adding the tasks to fill out the page and also to demonstrate the app
        Tasks = new ObservableCollection<MyTask>()
        {
            new MyTask
            {
                TaskName = "Dishes",
                Completed = false,
                CategoryId = 1,
            },
            new MyTask
            {
                TaskName = "Vacuum",
                Completed = false,
                CategoryId = 1,
            },
            new MyTask
            {
                TaskName = "Study for Task App exam",
                Completed = false,
                CategoryId = 2,
            },
            new MyTask
            {
                TaskName = "Finish Working on Back End",
                Completed = false,
                CategoryId = 2,
            },
            new MyTask
            {
                TaskName = "Buy Flour",
                Completed = false,
                CategoryId = 3,
            },
            new MyTask
            {
                TaskName = "Buy Protein Powder",
                Completed = false,
                CategoryId = 3,
            }
        };
    }
    //here i have the new task add function
    public class TaskAddedEventArgs : EventArgs
    {
        public MyTask NewTask { get; }

        public TaskAddedEventArgs(MyTask newTask)
        {
            NewTask = newTask;
        }
    }

    //here i am carrying on with the add task function
   public void AddTask()
    {
        if (SelectedCategory != null)
        {
            var newTask = new MyTask { TaskName = Task, Completed = false, CategoryId = SelectedCategory.Id };
            SelectedCategory.AddTask(newTask);
            TaskAdded?.Invoke(this, new TaskAddedEventArgs(newTask));
            Task = string.Empty;
        }
    }
}
