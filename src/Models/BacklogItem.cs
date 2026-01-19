using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class BacklogItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [EnumDataType(typeof(BacklogItemStatus))]
        public BacklogItemStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public BacklogItem()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public BacklogItem(string title, string description = null) : this()
        {
            Title = title;
            Description = description;
        }
    }

    public enum BacklogItemStatus
    {
        [Display(Name = "To Do")]
        ToDo,
        
        [Display(Name = "In Progress")]
        InProgress,
        
        [Display(Name = "Done")]
        Done
    }
}