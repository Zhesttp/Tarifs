// using Microsoft.AspNetCore.Identity;
// using System.ComponentModel.DataAnnotations.Schema;
// using System.ComponentModel.DataAnnotations;
// namespace Task_Management_System.Models
// {
//     public class ProjectUser
//     {
//         [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//         public string Id { get; set; }
//         public string ProjectsId { get; set; }
//         public string UsersId { get; set; }
//         public Project Project { get; set; } = null!;
//         public User User { get; set; } = null!;
//     }
// }