using System;
using System.Collections.Generic;

namespace ToDoListApp
{
    // TodoTask Class
    public class TodoTask
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }


        public void Display(int index)
        {
            string status = IsCompleted ? "[x]" : "[]" ;
            Console.WriteLine($"{index + 1}. {status} {Description}");
        }
    }

    internal class Program
    {

        // Add task function
        static void AddTask(List<TodoTask> tasks)
        {
            Console.WriteLine("Enter task description: ");
            string desc = Console.ReadLine();
            tasks.Add(new TodoTask { Description = desc , IsCompleted = false});
        }


        // View tasks functions
        static void ViewTasks(List<TodoTask> tasks)
        {
            Console.WriteLine("== Your Tasks ==");
            if(tasks.Count == 0)
            {
                Console.WriteLine("No tasks yet!");
            }else
            {
                for(int i  = 0; i < tasks.Count;i++)
                {
                    tasks[i].Display(i);
                }
            }
            Console.WriteLine("Press any key to return");
            Console.ReadKey();
        }


        // Complete Tasks
        static void CompleteTask(List<TodoTask> tasks)
        {
            ViewTasks(tasks);
            Console.WriteLine("Enter task number to mark as completed");
            if(int.TryParse(Console.ReadLine(), out int index))
            {
                index -= 1;
                if(index >= 0 && index < tasks.Count)
                {
                    tasks[index].IsCompleted = true;
                }
            }
        }


        // Delete Tasks
        static void DeleteTask(List<TodoTask> tasks)
        {
            ViewTasks(tasks);
            Console.WriteLine("enter task number to delete: ");
            if(int.TryParse(Console.ReadLine(), out int index))
            {
                index -= 1;
                if(index >= 0 && index < tasks.Count)
                {
                    tasks.RemoveAt(index);
                }
            }
        }


        static void Main(string[] args)
        {
            List<TodoTask> tasks = new List<TodoTask>();
            bool running = true;


            // Running App
            while (running)
            {
                Console.Clear();
                Console.WriteLine("== TO-DO LIST MENU ==");
                Console.WriteLine("1. View Tasks");
                Console.WriteLine("2. Add Tasks");
                Console.WriteLine("3. Mark Task as Completed");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewTasks(tasks);
                        break;
                    case "2":
                        AddTask(tasks);
                        break;
                    case "3":
                        CompleteTask(tasks);
                        break;
                    case "4":
                        DeleteTask(tasks);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to Continue...");
                        Console.ReadKey();
                        break;
                }
            }


        }
    }
}
