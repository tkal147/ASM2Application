using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ASM2.Models.FPT;

public class Trainer
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Please Enter your Name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please Enter your telephone")]
    public string Telephone { get; set; }
    [Required(ErrorMessage = "Please Enter your Email")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Please Enter your type")]
    public string Type { get; set; }
    [Required(ErrorMessage = "Please choose Working Place")]
    public string WorkingPlace { get; set; }
    public List<Course> Courses { get; set; }
}
