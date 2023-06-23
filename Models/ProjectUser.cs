using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Task_Management_System.Models
{
    public class ProjectUser
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProjectId { get; set; }
        public string UserId { get; set; }

        public Project Project { get; set; }
        public User User { get; set; }
    }
}