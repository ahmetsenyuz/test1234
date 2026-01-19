using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TodoApp.Models;

namespace TodoApp.Services
{
    public class TaskService
    {
        private readonly string _storagePath = "tasks.json";
        private List<Task> _tasks;
        
        public TaskService()
        {
            _tasks = LoadTasks();
        }
        
        public void AddTask(string description)
        {
            var task = new Task(description)
            {
                Id = _tasks.Count > 0 ? _tasks[_tasks.Count - 1].Id + 1 : 1
            };
            
            _tasks.Add(task);
            SaveTasks();
        }
        
        public List<Task> GetTasks()
        {
            return _tasks;
        }
        
        public void MarkTaskComplete(int index)
        {
            if (index >= 0 && index < _tasks.Count)
            {
                _tasks[index].IsCompleted = true;
                SaveTasks();
            }
        }
        
        public void DeleteTask(int index)
        {
            if (index >= 0 && index < _tasks.Count)
            {
                _tasks.RemoveAt(index);
                SaveTasks();
            }
        }
        
        private List<Task> LoadTasks()
        {
            if (!File.Exists(_storagePath))
            {
                return new List<Task>();
            }
            
            var json = File.ReadAllText(_storagePath);
            return JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
        }
        
        private void SaveTasks()
        {
            var json = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_storagePath, json);
        }
    }
}