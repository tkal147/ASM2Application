using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASM2.Models.FPT
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descrpitipon { get; set; }
        public List<Trainee> Trainee { get; set; }
        public List<Trainer> Trainer { get; set; }
        //public int CatId { get; set; }
        public Categories Category { get; set; }
    }
}