using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Task_Management_System.Models;
using Task_Management_System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Task_Management_System.Controllers
{
    public class TasksController : Controller
    {
        public string Email;
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var tasks = _context.Tasks.ToList();
            ViewBag.Tasks = tasks;
            return View(tasks);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var task = _context.Tasks.Where(x => x.Id == id);
            ViewBag.Task = task.ToList().ElementAt(0);
            return View(task);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Create(Models.Task task, string projectId, string email)
        {
            try
            {
                task.AssigneeId = _context.Users.FirstOrDefault(user => user.Email == email).Id;
                task.ProjectId = projectId;
                _context.Tasks.Add(task);
                _context.SaveChanges();
                ViewBag.Message = "Data Insert Successfully";
                return View(task);
            }
            catch (Exception ex)
            {
                return View(ex.Message); // An error occured
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id, string projectId)
        {
            var task = _context.Tasks.FirstOrDefault(task => task.Id == id);
            task.AssigneeId = _context.Users.FirstOrDefault(user => user.Email == User.Identity.Name).Id;
            task.ProjectId = projectId;
            return View(task);
        }
        [HttpPost, ActionName("Edit"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Models.Task task)
        {
            if(task == null){
                return NotFound();
            }
            _context.Update(task);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}