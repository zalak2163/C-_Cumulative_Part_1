using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C__Cumulative_Part_1.Models;
using Mysqlx.Datatypes;

namespace C__Cumulative_Part_1.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
		//GET : /Teacher/List
		public ActionResult List(string SearchKey = null)
		{
			TeacherDataController controller = new TeacherDataController();
			IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
			return View(Teachers);
		}

		//GET : /Teacher/Show/{id}
		public ActionResult Show(int id)
		{
			TeacherDataController controller = new TeacherDataController();
			Teacher Newteacher = controller.FindTeacher(id);


			return View(Newteacher);
		}

		//GET : /Teacher/New
		public ActionResult New()
		{
			//Renders the page/ Views/Teacher/New.cshtml
			return View();
		}

		//POST : /Teacher/Create
		[HttpPost]
		public ActionResult Create(int teacherid, string teacherfname, string teacherlname, string employeenumber, string hiredate, string salary)
		{
			//Identify that this method is running
			//Identify the inputs provided from the form

			Debug.WriteLine("I have accessed the Create Method!");
			Debug.WriteLine(teacherid);
			Debug.WriteLine(teacherfname);
			Debug.WriteLine(teacherlname);
			Debug.WriteLine(employeenumber);
			Debug.WriteLine(hiredate);
			Debug.WriteLine(salary);


			Teacher Newteacher = new Teacher();
			Newteacher.teacherid = teacherid;
			Newteacher.teacherfname = teacherfname;
			Newteacher.teacherlname = teacherlname;
			Newteacher.employeenumber = employeenumber;
			Newteacher.hiredate = hiredate;
			Newteacher.salary = salary;

			TeacherDataController controller = new TeacherDataController();
			controller.AddTeacher(Newteacher);

			return RedirectToAction("List");
		}

		//POST : /Teacher/Delete/{id}
		[HttpPost]
		public ActionResult Delete(int id)
		{
			TeacherDataController controller = new TeacherDataController();
			controller.DeleteTeacher(id);
			return RedirectToAction("List");
		}

		//GET : /Teacher/DeleteConfirm/{id}
		public ActionResult DeleteConfirm(int id)
		{
			TeacherDataController controller = new TeacherDataController();
			Teacher NewTeacher = controller.FindTeacher(id);


			return View(NewTeacher);
		}
	}
}