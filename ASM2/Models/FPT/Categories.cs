using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASM2.Models.FPT
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descrpitipon { get; set; }
        public List<Course> CourseOwned { get; set; }
    }
}