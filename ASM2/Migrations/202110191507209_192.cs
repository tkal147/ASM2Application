namespace ASM2.Migrations
{
    using ASM2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    public partial class _192 : DbMigration
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
                UserName = "Xyz@12345" + i,
                Email = "Xyz@12345" + i,
                Name = "Trainer"+i,
                Role = "Trainer"
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

            for (int x = 100; x < 120; x++)
            {
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
