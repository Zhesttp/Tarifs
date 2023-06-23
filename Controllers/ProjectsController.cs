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
            var projects = _context.Projects.ToList();
            ViewBag.Projects = projects;
            return View(projects);
        }
        [HttpGet]
        public ActionResult Details(string id)
        {
            var projectTasks = _context.Tasks.Where(task => task.ProjectId == id);
            var project = _context.Projects.First(p => p.Id == id);
            ViewBag.Project = project;
            ViewBag.Tasks =  projectTasks;
            return View(project);
        }
        [HttpGet]
        public ActionResult Edit(string? id)
        {
            return View();
        }
        [HttpPost]
        public ViewResult Edit(Project project)
        {
            string currentUserId = _context.Users.FirstOrDefault(user => user.Email == User.Identity.Name).Id;
            project.CreatorId = currentUserId;
            _context.Projects.Update(project);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
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
            project.CreatorId = currentUserId;
            _context.Projects.Add(project);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
    }
}