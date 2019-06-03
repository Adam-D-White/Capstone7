using CapstoneWeek6TaskList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneWeek6TaskList.Controllers
{
    public class TaskListController : Controller
    {
        private TaskListDbEntities ORM = new TaskListDbEntities();
        // GET: TaskList
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Tasks()
        {
            ViewBag.Task = ORM.StoreTasks.ToList();

            return View();
            
        }

        public ActionResult AddTask()
        {
            return View();
        }

        public ActionResult SaveNewTask(StoreTask  newTask)
        {
            //Checks if all required info is entered
            if (ModelState.IsValid)
            {
                //Adds the product and saves to DB 
                ORM.StoreTasks.Add(newTask);
                ORM.SaveChanges();
                //Returning to action to display updated list
                return RedirectToAction("Tasks");
            }
            else
            {
                ViewBag.ErrorMessage = "Something went wrong.";
                return View("AddTask");
            }



        }

        public ActionResult AddUser()
        {
            return View();
        }

        public ActionResult SaveNewUser(User newUser)
        {
            //Checks if all required info is entered
            if (ModelState.IsValid)
            {
                //Adds the product and saves to DB 
                ORM.StoreTasks.Add(newUser);
                ORM.SaveChanges();
                //Returning to action to display updated list
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Something went wrong.";
                return View("AddTask");
            }



        }

    }
}