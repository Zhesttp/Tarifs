using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Management_System.Models
{
    public class Task
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        [DefaultValue(Models.Progress.Backlog)]
        public Progress Progress { get; set; }
        public string ProjectId { get; set; }
        public Project Project { get; set; }
        public string AssigneeId { get; set; }
        public User Assignee { get; set; }
    }
}