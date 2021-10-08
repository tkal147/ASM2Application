using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ASM2.Models.FPT;

public class Trainee
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Please choose Name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please choose Education")]
    public string Education { get; set; }
    [Required(ErrorMessage = "Please choose DOB")]
    public string DOB { get; set; }
    [Required(ErrorMessage = "Please choose Age")]
    public string Age { get; set; }
    [Required(ErrorMessage = "Please choose Department")]
    public string Department { get; set; }
    [Required(ErrorMessage = "Please choose Toeic")]
    public string TOEIC { get; set; }
    [Required(ErrorMessage = "Please choose Location")]
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
