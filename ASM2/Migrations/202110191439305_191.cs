namespace ASM2.Migrations
{
    using System;
    using System.Security.Cryptography;
    using System.Data.Entity.Migrations;
    using System.Text;
    using ASM2.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Web.Mvc;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;

    public partial class _191 : DbMigration
    {
        public override void Up()
        {
            RunAsync();

        
        }

        public async Task CreateTrainee(int i)
        {

            var db = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new ApplicationUserManager(userStore);


            var user = new ApplicationUser
            {
                UserName = "Trainee@gmail.com"+i,
                Email = "Trainee@gmail.com" + i,
                Name = "Trainee" + i,
                Role = "Trainee"
            };
            var result = await userManager.CreateAsync(user, "Xyz@12345");
            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, user.Role);
            }

        }

        public async Task RunAsync()
        {
            
            var tasks = new List<Task>();

            for (int x = 0;x<100;x++) { 
                var task = CreateTrainee(x);
                tasks.Add(task);
            }

            await Task.WhenAll();
        }

        public override void Down()
        {
        }
    }
}
