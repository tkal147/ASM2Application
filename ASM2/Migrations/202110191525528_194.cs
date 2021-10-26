namespace ASM2.Migrations
{
    using ASM2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Threading.Tasks;

    public partial class _194 : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Courses ON");
            for (int i = 11; i < 21; i++)
            {
                
                Sql("INSERT INTO dbo.Courses (Id, Name, Descrpitipon, CatId) VALUES " +
        $"({i},'Course{i}', 'Database', 1) ");

            }
            CreateAdmin(999);
        }
        public async Task CreateAdmin(int i)
        {

            var db = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new ApplicationUserManager(userStore);


            var user = new ApplicationUser
            {
                UserName = "Admin@gmail.com" + i,
                Email = "Admin@gmail.com" + i,
                Name = "Amin",
                Role = "Admin"
            };
            var result = await userManager.CreateAsync(user, "Xyz@12345");
            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, user.Role);
            }

        }
        public override void Down()
        {
        }
    }
}
