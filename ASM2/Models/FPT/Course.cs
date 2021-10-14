using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASM2.Models.FPT
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter  your Descrpition")]
        public string Descrpitipon { get; set; }
        
        public List<Trainee> Trainee { get; set; }
        
        public List<Trainer> Trainer { get; set; }
        public int CatId { get; set; }
        //public Categories Category { get; set; }
    }
}