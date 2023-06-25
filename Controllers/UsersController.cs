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
    public async Task<IActionResult> Destroy(string? id)
    {
        Console.WriteLine($"\n\n\n\n\n{id}");
        var project = _context.Projects.FirstOrDefault(p => p.Id == id);
        var currentUser = _context.Users.FirstOrDefault(user => user.Email == User.Identity.Name);
        _context.Projects.Remove(project);
        currentUser.Projects.Remove(project);
        await _context.SaveChangesAsync();
        return Redirect("/Users/Details/");
    }
}
