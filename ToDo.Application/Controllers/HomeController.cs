using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Bussiness;
using ToDo.Data.Model;

namespace ToDo_Application.Controllers
{
    public class HomeController : Controller
    {
        DataAccess dataAccess = new DataAccess();
        TasksList tasksList = new TasksList();

        public ActionResult Index()
        {
            return View(dataAccess.TaskList());
        }

        public ActionResult AddList()
        {
            return PartialView();
        }

        public ActionResult AddToDoList(TasksList id)
        {
            dataAccess.AddCategory(id);
            return PartialView("ToDoList", dataAccess.Tasks());
        }

        public ActionResult DisplayLists()
        {
            return View(dataAccess.TaskList());
        }

        public ActionResult Today()
        {
            return PartialView(dataAccess.Tasks());
        }

        public ActionResult ToDoList()
        {
            return PartialView(dataAccess.Tasks());
        }

        public ActionResult AddToDo(TasksList tasksList)
        {
            dataAccess.AddToDo(tasksList);
            return PartialView("ToDoList", dataAccess.Tasks());
        }

        public ActionResult Categories()
        {
            return View(dataAccess.TaskList());
        }

        public ActionResult AddToDoTask()
        {
            return View();
        }

        public ActionResult SelectedTask()
        {
            return View(dataAccess.TaskList());
        }

        public ActionResult SelectedList(string id)
        {
            ViewBag.SelectedList = id;
            return PartialView(dataAccess.Tasks());
        }

        public ActionResult DetailsWidget(string id, string notes)
        {
            ViewBag.SelectedToDo = id;
            ViewBag.SelectedTask = notes;
            return PartialView(dataAccess.Tasks());
        }

        public ActionResult UpdateToDo(TasksList tasksList)
        {
            dataAccess.UpdateToDo(tasksList);
            return PartialView("ToDoList", dataAccess.Tasks());
        }

        public ActionResult DeleteToDo(string id)
        {
            dataAccess.DeleteToDo(id);
            return PartialView("ToDoList", dataAccess.Tasks());
        }
    }
}