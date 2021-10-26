using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ASM2.Models.FPT;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        //staff, admin, trainer, trainee
        public string Role { get; set; }
        //staff, admin
        public string Contact { get; set; }
        //trainee
        public string Education { get; set; }
        ///trainee
        public string DOB { get; set; }
        //trainee
        public string Age { get; set; }
        //trainee
        public string Department { get; set; }
        //trainee
        public string TOEIC { get; set; }
        //trainee
        public string Location { get; set; }
        //trainer
        public string Telephone { get; set; }
        //trainer
        public string Type { get; set; }
        //trainer
        public string WorkingPlace { get; set; }
        //trainer, trainee
        public List<Course> Course { get; set; }
        public ApplicationUser()
        {
            Course = new List<Course>();
            
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("BwConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Course> Course { get; set; }
        
        public DbSet<Categories> Categories { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder) // override DbContext's
        //{
        //    modelBuilder.Entity<Course>()
        //                .ToTable("Course"); //table name in db

        //    modelBuilder.Entity<Course>()
        //                .HasKey<int>(b => b.Id);  //setup PK



        //    modelBuilder.Entity<Categories>()
        //                .ToTable("Categories"); //table name in db

        //    modelBuilder.Entity<Categories>()
        //                .HasKey<int>(b => b.Id);  //setup PK

        //}
    }
}