using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Management_System.Models
{
    public class User : IdentityUser
    {
        [DefaultValue(Role.User)]
        public Role Role { get; set; }

        public string FirstName { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Models.Task> Tasks { get; set; }
    }
}