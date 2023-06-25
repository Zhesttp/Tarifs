using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Models;
using Task_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
namespace Task_Management_System.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly AppDbContext _context;

        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var cUser = _context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            ViewBag.CurrUser = cUser;
            var projects = _context.Projects.ToList();
            ViewBag.Projects = projects;
            return View(projects);
        }
        [HttpGet]
        public IActionResult Details(string id)
        {
            var projectTasks = _context.Tasks.Where(task => task.ProjectId == id);
            var project = _context.Projects.First(p => p.Id == id);
            ViewBag.Project = project;
            ViewBag.Tasks =  projectTasks;
            return View(project);
        }
        [HttpGet]
        public IActionResult Edit(string? id)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Id == id);
            var currentUser = _context.Users.FirstOrDefault(user => user.Email == User.Identity.Name);
            if (!_context.Users.FirstOrDefault(u => u.Id == currentUser.Id).Projects.Exists(p => p.Id == project.Id))
            {
                currentUser.Projects.Add(project);
                // _context.Projects.Update(project);
                _context.SaveChanges();
                ViewBag.Message = "Data Insert Successfully";
            }
            return Redirect("/Users/Details/");
        }
        [HttpPost]
        public IActionResult Edit(Project project)
        {
            var currentUser = _context.Users.FirstOrDefault(user => user.Email == User.Identity.Name);
            if (!_context.Users.FirstOrDefault(u => u.Id == currentUser.Id).Projects.Exists(p => p.Id == project.Id))
            {
                currentUser.Projects.Add(project);
                // _context.Projects.Update(project);
                _context.SaveChanges();
                ViewBag.Message = "Data Insert Successfully";
            }

            return Redirect("/Users/Details/");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Create(Project project)
        {
            string currentUserId = _context.Users.FirstOrDefault(user => user.Email == User.Identity.Name).Id;
            _context.Projects.Add(project);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
    }
}