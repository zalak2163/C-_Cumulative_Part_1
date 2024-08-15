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
		public ActionResult Create(int teacherid, string teacherfname, string teacherlname, string employeenumber, DateTime hiredate, decimal salary)
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
		/// <summary>
		/// Routes to a dynamically generated "Teacher Update" Page. Gathers information from the database.
		/// </summary>
		/// <param name="id">Id of the Teacher</param>
		/// <returns>A dynamic "Update Teacher" webpage which provides the current information of the teacher and asks the user for new information as part of a form.</returns>
		/// <example>GET : /Teacher/Update/5</example>
		public ActionResult Update(int id)
		{
			TeacherDataController controller = new TeacherDataController();
			Teacher SelectedTeacher = controller.FindTeacher(id);

			return View(SelectedTeacher);
		}



		/// <summary>
		/// Receives a POST request containing information about an existing teacher in the system, with new values. Conveys this information to the API, and redirects to the "Teacher Show" page of our updated teacher.
		/// </summary>
		/// <param name="id">Id of the Teacher to update</param>
		/// <param name="teacherfname">The updated first name of the Teacher</param>
		/// <param name="teacherlname">The updated last name of the Teacher</param>
		/// <param name="employeenumber">The updated employeenumber of the Teacher.</param>
		/// <param name="hiredate">The updated hiredate of the Teacher.</param>
		/// <param name="salary">The updated salary of the Teacher.</param>
		/// <returns>A dynamic webpage which provides the current information of the Teacher.</returns>
		[HttpPost]
		public ActionResult Update(int id, string teacherfname, string teacherlname, string employeenumber, DateTime hiredate, decimal salary)
		{
			Teacher TeacherInfo = new Teacher();
			TeacherInfo.teacherfname = teacherfname;
			TeacherInfo.teacherlname = teacherlname;
			TeacherInfo.employeenumber = employeenumber;
			TeacherInfo.hiredate = hiredate;
			TeacherInfo.salary = salary;

			TeacherDataController controller = new TeacherDataController();
			controller.UpdateTeacher(id, TeacherInfo);

			return RedirectToAction("Show/" + id);
		}

	}
}
	
