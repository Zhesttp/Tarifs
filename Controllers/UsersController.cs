using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Data;

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
}
    