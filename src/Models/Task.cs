using System;

namespace TodoApp.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public Task()
        {
            CreatedAt = DateTime.Now;
        }
        
        public Task(string description) : this()
        {
            Description = description;
        }
    }
}