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
                CategoryName = "Inventory Management",
                Color = "#84B94A"
            },
            new Category
            {
                Id = 2,
                CategoryName = "Order Processing",
                Color = "#E09735"
            },
            new Category
            {
                Id = 3,
                CategoryName = "Scheduling",
                Color = "#D935E0"
            },
            new Category
            {
                Id= 4,
                CategoryName = "Customer Interactions",
                Color = "Pink"
            }
        };

        //here i am adding the default tasks to the page
        Tasks = new ObservableCollection<MyTask>()
        {
                new MyTask
            {
                TaskName = "Look over storage for products getting low",
                Completed = false,
                CategoryId = 1,
            },
            new MyTask
            {
                TaskName = "Add products to the grocery list if needed",
                Completed = false,
                CategoryId = 1,
            },
            new MyTask
            {
                TaskName = "Sort through orders",
                Completed = false,
                CategoryId = 2,
            },
            new MyTask
            {
                TaskName = "Pack orders",
                Completed = false,
                CategoryId = 2,
            },

            new MyTask
            {
                TaskName = "Look through day",
                Completed = false,
                CategoryId = 3,
            },
            new MyTask
            {
                TaskName = "Deligate Jobs to staff",
                Completed = false,
                CategoryId = 3,
            },
            new MyTask
            {
                TaskName = "Check Google Reviews and answer new reviews",
                Completed = false,
                CategoryId = 4,
            },
            new MyTask
            {
                TaskName = "Check Emails and Respond to emails",
                Completed = false,
                CategoryId = 4,
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
