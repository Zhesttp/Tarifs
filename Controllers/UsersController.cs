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
        var user = _context.Users.First(u => u.Email == User.Identity.Name);
        ViewBag.Tarifs = user.Projects;
        return View();
    }
}
