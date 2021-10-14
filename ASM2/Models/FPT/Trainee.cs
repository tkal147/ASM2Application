using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ASM2.Models.FPT;

public class Trainee
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Please Enter your Name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please Enter your Education")]
    public string Education { get; set; }
    [Required(ErrorMessage = "Please Enter your DOB")]
    public string DOB { get; set; }
    [Required(ErrorMessage = "Please choose your Age")]
    public string Age { get; set; }
    [Required(ErrorMessage = "Please Enter your Department")]
    public string Department { get; set; }
    [Required(ErrorMessage = "Please Enter your Toeic")]
    public string TOEIC { get; set; }
    [Required(ErrorMessage = "Please Enter your Location")]
    public string Location { get; set; }
   
    public Course Course { get; set; }
    public string ToSeparatedString(string separator)
    {
        return $"{this.Name}{separator}";

    }
    public string getId(string separator)
    {
        return $"{this.Id}{separator}";

    }

}
