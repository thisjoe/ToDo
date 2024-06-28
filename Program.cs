using System;
using System.Collections.Generic;

namespace ToDoListApp
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    class Program
    {
        private static List<Task> tasks = new List<Task>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your To-Do List!");

            while (true)
            {
                Menu();
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice.ToLower())
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        DeleteTask();
                        break;
                    case "3":
                        ListTasks();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void Menu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Remove Task");
            Console.WriteLine("3. List Tasks");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
        }

        static void AddTask()
        {
            Console.Write("Enter task description: ");
            string description = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(description))
            {
                Task newTask = new Task { Id = tasks.Count + 1, Description = description };
                tasks.Add(newTask);
                Console.WriteLine("Task added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid task description.");
            }
        }

        static void DeleteTask()
        {
            ListTasks();
            Console.Write("Enter task number to remove: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
            {
                tasks.RemoveAt(index - 1);
                Console.WriteLine("Task removed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }

        static void ListTasks()
        {
            Console.WriteLine("Tasks:");
            if (tasks.Count > 0)
            {
                foreach (var task in tasks)
                {
                    Console.WriteLine($"- {task.Id}. {task.Description}");
                }
            }
            else
            {
                Console.WriteLine("No tasks.");
            }
        }
    }
}