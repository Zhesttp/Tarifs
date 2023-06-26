using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Task_Management_System.Controllers;
public class UsersController : Controller
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult Index()
    {
        var users = _context.Users.ToList();
        ViewBag.User = _context.Users;
        return View();
    }
    [HttpGet]
    public IActionResult Details()
    {
        var user = _context.Projects.Where(p =>
            p.Users.FirstOrDefault(u => u.Email == User.Identity.Name).Email == User.Identity.Name);
        ViewBag.Tarifs = user;
        return View();
    }

    [HttpGet]
    public IActionResult Destroy(string? id)
    {
        var project = _context.Projects.Include(p => p.Users).Single(u => u.Id == id);
        var currentUser = _context.Users.Single(user => user.Email == User.Identity.Name);
        project.Users.Remove(project.Users.Where(u => u.Id == currentUser.Id).FirstOrDefault());
        _context.SaveChanges();


//         var groupToUpdate = _userGroupsContext.Groups.Include(g => g.UserGroups).Single(u => u.Id == userVm.groupsIds[0]);
// var userToUpdate = _userGroupsContext.Users.Single(u => u.Id == userVm.user.Id);

// groupToUpdate.UserGroups.Remove(groupToUpdate.UserGroups.Where(ugu => ugu.UserId == userToUpdate.Id).FirstOrDefault());
// _userGroupsContext.SaveChanges();
        return Redirect("/Users/Details/");
    }
}
