using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using StudentsViewTemplateDemo.Models;

namespace StudentsViewTemplateDemo
{
   //[RoutePrefix("students")]
    public class StudentController : Controller
    {
        static List<Student> students = new List<Student>() {
            new Student() { Id = 1,
                Name="Allen",
                Age=34,
                Address=new Address(){
                    Id=101,
                    Country="India",
                    State="Goa",
                    City="Panjim"
                    }

            },
            new Student(){
                Id=2,
                Name="Mary",
                Age=42,
                Address=new Address(){
                    Id=101,
                    Country="India",
                    State="Punjab",
                    City="Mohali"
                }
            }
        };

        // GET: Student
        [Route("")]

        public ActionResult GetAllStudents()
        {
            var data = students;
            return View(data);
        }
        ////[Route("{id}")]
        //public ActionResult GetStudentById(int id)
        //{
        //    var student = students.FirstOrDefault(st => st.Id == id);
        //    return View(student);
        //}
        ////[Route("address/{id}")]
        //public ActionResult GetAddressOfStudentById(int id)
        //{
        //    var studentAddress = students.Where(st => st.Id == id).Select(st => st.Address).FirstOrDefault();

        //    return View(studentAddress);
        //}
        ////[Route("~/aboutUs")]
        //public string AboutUs()
        //{
        //    return "This is about us";
        //}
        [HttpGet]
        [Route("add")]

        public ActionResult AddStudent()
        {
            
            return View();

        }

        [HttpGet]
        [Route("update/{id}")]

        public ActionResult UpdateStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        [HttpPost]
        [Route("update/{id}")]

        public ActionResult UpdateStudent(Student updatedStudent)
        {
            if (ModelState.IsValid) // Ensure model is valid before updating
            {
                var student = students.FirstOrDefault(s => s.Id == updatedStudent.Id);
                if (student != null)
                {
                    student.Name = updatedStudent.Name;
                    student.Age = updatedStudent.Age;
                    student.Address = updatedStudent.Address;
                    return RedirectToAction("GetAllStudents");
                }
            }
            return View(updatedStudent);

        }

        [Route("delete/{id}")]
        public ActionResult DeleteStudent() { return View(); }

        [HttpPost]
        [Route("add")]

        public ActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                students.Add(student);
                return RedirectToAction("GetAllStudents");
            }
            return View(student);

        }
        
     
        [HttpPost]
        [Route("delete/{id}")]

        public ActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
            return RedirectToAction("GetAllStudents");
        }


    }
}