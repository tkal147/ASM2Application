using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASM2.Models.FPT;

public class Trainer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }
    public string Type { get; set; }
    public string WorkingPlace { get; set; }
    public List<Course> Courses { get; set; }
}
