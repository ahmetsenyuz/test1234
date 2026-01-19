using System;
using System.IO;
using System.Text.Json;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the To-Do Application!");
            
            var taskService = new TaskService();
            
            while (true)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. List Tasks");
                Console.WriteLine("3. Mark Task as Complete");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Exit");
                
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        AddTask(taskService);
                        break;
                    case "2":
                        ListTasks(taskService);
                        break;
                    case "3":
                        MarkTaskComplete(taskService);
                        break;
                    case "4":
                        DeleteTask(taskService);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        
        static void AddTask(TaskService taskService)
        {
            Console.Write("Enter task description: ");
            var description = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(description))
            {
                taskService.AddTask(description);
                Console.WriteLine("Task added successfully!");
            }
            else
            {
                Console.WriteLine("Task description cannot be empty.");
            }
        }
        
        static void ListTasks(TaskService taskService)
        {
            var tasks = taskService.GetTasks();
            
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                return;
            }
            
            Console.WriteLine("\nTasks:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"[{(task.IsCompleted ? "X" : " ")}] {task.Description}");
            }
        }
        
        static void MarkTaskComplete(TaskService taskService)
        {
            ListTasks(taskService);
            
            Console.Write("Enter task number to mark as complete: ");
            var input = Console.ReadLine();
            
            if (int.TryParse(input, out int taskNumber) && taskNumber > 0)
            {
                taskService.MarkTaskComplete(taskNumber - 1);
                Console.WriteLine("Task marked as complete!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }
        
        static void DeleteTask(TaskService taskService)
        {
            ListTasks(taskService);
            
            Console.Write("Enter task number to delete: ");
            var input = Console.ReadLine();
            
            if (int.TryParse(input, out int taskNumber) && taskNumber > 0)
            {
                taskService.DeleteTask(taskNumber - 1);
                Console.WriteLine("Task deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }
    }
}