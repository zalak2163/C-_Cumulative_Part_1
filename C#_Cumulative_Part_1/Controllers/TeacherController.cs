using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C__Cumulative_Part_1.Models;

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

	}
}