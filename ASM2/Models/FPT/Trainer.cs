using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ASM2.Models.FPT;

public class Trainer
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Please choose Name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please choose telephone")]
    public string Telephone { get; set; }
    [Required(ErrorMessage = "Please choose Email")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Please choose type")]
    public string Type { get; set; }
    [Required(ErrorMessage = "Please choose Working Place")]
    public string WorkingPlace { get; set; }
    public List<Course> Courses { get; set; }
}
