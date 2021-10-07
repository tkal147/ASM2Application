namespace ASM2.EF.FPTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO dbo.Admin (Name, Contact) VALUES " +
        "('Thai', '0972921123') ");
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Descrpitipon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO dbo.Categories (Name, Descrpitipon) VALUES " +
        "('IT', 'CNTT') ");
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Descrpitipon = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            Sql("INSERT INTO dbo.Course (Name, Descrpitipon,Category_Id) VALUES " +
        "('IT', 'CNTT',1) ");
            CreateTable(
                "dbo.Trainee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Education = c.String(),
                        DOB = c.String(),
                        Age = c.String(),
                        Department = c.String(),
                        TOEIC = c.String(),
                        Location = c.String(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .Index(t => t.Course_Id);
            Sql("INSERT INTO dbo.Trainee (Name, Education,DOB,Age,Department,TOEIC,Location,Course_Id) VALUES " +
        "('Thai', '12','12/5/2001','19','depart','7.5','Tay Coc','1') ");
            CreateTable(
                "dbo.Trainer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Telephone = c.String(),
                        Email = c.String(),
                        Type = c.String(),
                        WorkingPlace = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO dbo.Trainer ( Telephone,Email,Type,WorkingPlace) VALUES " +
        "( '09123456789','hello@gmail.com','hello','FPT') ");
            CreateTable(
                "dbo.TrainingStaff",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO dbo.TrainingStaff (Name, Contact) VALUES " +
        "('Thai', '0972921123') ");
            CreateTable(
                "dbo.TrainerCourses",
                c => new
                    {
                        Trainer_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Trainer_Id, t.Course_Id })
                .ForeignKey("dbo.Trainer", t => t.Trainer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Trainer_Id)
                .Index(t => t.Course_Id);
            Sql("INSERT INTO dbo.TrainerCourses (Trainer_Id, Course_Id) VALUES " +
        "(1, 1) ");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainerCourses", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.TrainerCourses", "Trainer_Id", "dbo.Trainer");
            DropForeignKey("dbo.Trainee", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.Course", "Category_Id", "dbo.Categories");
            DropIndex("dbo.TrainerCourses", new[] { "Course_Id" });
            DropIndex("dbo.TrainerCourses", new[] { "Trainer_Id" });
            DropIndex("dbo.Trainee", new[] { "Course_Id" });
            DropIndex("dbo.Course", new[] { "Category_Id" });
            DropTable("dbo.TrainerCourses");
            DropTable("dbo.TrainingStaff");
            DropTable("dbo.Trainer");
            DropTable("dbo.Trainee");
            DropTable("dbo.Course");
            DropTable("dbo.Categories");
            DropTable("dbo.Admin");
        }
    }
}
