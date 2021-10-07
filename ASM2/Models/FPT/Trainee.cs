using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASM2.Models.FPT;

    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Education { get; set; }
        public string DOB { get; set; }
        public string Age { get; set; }
        public string Department { get; set; }
        public string TOEIC { get; set; }
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
