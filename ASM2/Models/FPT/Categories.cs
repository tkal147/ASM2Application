using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ASM2.Models.FPT
{
    public class Categories
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Descrpition")]
        public string Descrpitipon { get; set; }
        public List<Course> CourseOwned { get; set; }
    }
}