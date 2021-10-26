namespace ASM2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _152 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CourseApplicationUsers", newName: "ApplicationUserCourses");
            DropPrimaryKey("dbo.ApplicationUserCourses");
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Descrpitipon = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "Categories_Id", c => c.Int());
            AddPrimaryKey("dbo.ApplicationUserCourses", new[] { "ApplicationUser_Id", "Course_Id" });
            CreateIndex("dbo.Courses", "Categories_Id");
            AddForeignKey("dbo.Courses", "Categories_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Categories_Id", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Categories_Id" });
            DropPrimaryKey("dbo.ApplicationUserCourses");
            DropColumn("dbo.Courses", "Categories_Id");
            DropTable("dbo.Categories");
            AddPrimaryKey("dbo.ApplicationUserCourses", new[] { "Course_Id", "ApplicationUser_Id" });
            RenameTable(name: "dbo.ApplicationUserCourses", newName: "CourseApplicationUsers");
        }
    }
}
