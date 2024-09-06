using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;


namespace StudentsViewTemplateDemo.Models
{
    
        public class Student
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Name is required")]
            [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Age is required")]
            [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
            public int Age { get; set; }

            [Required(ErrorMessage = "Address is required")]
            public Address Address { get; set; }
        }
    
}