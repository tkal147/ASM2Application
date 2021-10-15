using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASM2.Models.FPT
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        //staff, admin, trainer, trainee
        public string Role { get; set; }
        //staff, admin
        public string Contact { get; set; }
        //trainee
        public string Education { get; set; }
        ///trainee
        public string DOB { get; set; }
        //trainee
        public string Age { get; set; }
        //trainee
        public string Department { get; set; }
        //trainee
        public string TOEIC { get; set; }
        //trainee
        public string Location { get; set; }
        //trainer
        public string Telephone { get; set; }
        //trainer
        public string Email { get; set; }
        //trainer
        public string Type { get; set; }
        //trainer
        public string WorkingPlace { get; set; }
        //trainer, trainee
        public List<Course> Courses { get; set; }
        //all

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}