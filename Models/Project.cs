using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Management_System.Models
{
    public class Project
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ICollection<Task_Management_System.Models.Task> Tasks;
        public List<User> Users { get; } = new();
    }
}