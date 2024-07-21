using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using C__Cumulative_Part_1.Models;
using MySql.Data.MySqlClient;

namespace C__Cumulative_Part_1.Controllers
{
    public class TeacherDataController : ApiController
    {
		// The database context class which allows us to access our MySQL Database.
		private SchoolDbContext http5125_school = new SchoolDbContext();
		//This Controller Will access the authors table of our blog database.
		/// <summary>
		/// Returns a list of Teacher in the system
		/// </summary>
		/// <example>GET api/TeacherData/ListTeachers</example>
		/// <returns>
		/// A list of Teacher (first names and last names)
		/// </returns>
		[HttpGet]
		[Route("api/TeacherData/ListTeacher/{SearchKey?}")]
        public IEnumerable<Teacher> ListTeachers(string SearchKey = null)
        {
			//Create an instance of a connection
			MySqlConnection Conn = http5125_school.AccessDatabase();

			//Open the connection between the web server and database
			Conn.Open();

			//Establish a new command (query) for our database
			MySqlCommand cmd = Conn.CreateCommand();


			//SQL QUERY
			
			cmd.CommandText = "Select * from teachers where lower(teacherfname) like lower(@key) or lower(teacherlname) like lower(@key) or lower(concat(teacherfname, ' ', teacherlname)) like lower(@key)";
			cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");

			//Gather Result Set of Query into a variable
			MySqlDataReader ResultSet = cmd.ExecuteReader();

			//Create an empty list of Teachers
			List<Teacher> Teacher = new List<Teacher> {};

			//Loop Through Each Row the Result Set
			while (ResultSet.Read())
            {

				//Access Column information by the DB column name as an index
				int teacherid = (int)ResultSet["teacherid"];
				string teacherfname = ResultSet["teacherfname"].ToString();
				string teacherlname = ResultSet["teacherlname"].ToString();
				string employeenumber = ResultSet["employeenumber"].ToString();
				string hiredate = ResultSet["hiredate"].ToString();
				string salary = ResultSet["salary" +
					""].ToString();


				Teacher Newteacher = new Teacher();
				Newteacher.teacherid = teacherid;
				Newteacher.teacherfname = teacherfname;
				Newteacher.teacherlname = teacherlname;
				Newteacher.employeenumber = employeenumber;
				Newteacher.hiredate = hiredate;
				Newteacher.salary = salary;

				//Add the Teacher Name to the List
				Teacher.Add(Newteacher);

			}
			//Close the connection between the MySQL Database and the WebServer
			Conn.Close();

			//Return the final list of Teacher names
			return Teacher;
		}


		/// <summary>
		/// Finds an teacher in the system given an ID
		/// </summary>
		/// <param name="id">The teacher primary key</param>
		/// <returns>An teacher object</returns>
		[HttpGet]
		public Teacher FindTeacher(int id)
		{
			Teacher Newteacher = new Teacher();

			//Create an instance of a connection
			MySqlConnection Conn = http5125_school.AccessDatabase();

			//Open the connection between the web server and database
			Conn.Open();

			//Establish a new command (query) for our database
			MySqlCommand cmd = Conn.CreateCommand();

			//SQL QUERY
			cmd.CommandText = "Select * from teachers where teacherid = " + id;

			//Gather Result Set of Query into a variable
			MySqlDataReader ResultSet = cmd.ExecuteReader();

			while (ResultSet.Read())
			{
				//Access Column information by the DB column name as an index
				int teacherid = (int)ResultSet["teacherid"];
				string teacherfname = ResultSet["teacherfname"].ToString();
				string teacherlname = ResultSet["teacherlname"].ToString();
				string employeenumber = ResultSet["employeenumber"].ToString();
				string hiredate = ResultSet["hiredate"].ToString();
				string salary = ResultSet["salary"].ToString();


				Newteacher.teacherid = teacherid;
				Newteacher.teacherfname = teacherfname;
				Newteacher.teacherlname = teacherlname;
				Newteacher.employeenumber = employeenumber;
				Newteacher.hiredate = hiredate;
				Newteacher.salary = salary;
			}
				
				return Newteacher;
			
		}
	}
}