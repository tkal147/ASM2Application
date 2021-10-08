namespace ASM2.EF.FPTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Descrpitipon", c => c.String(nullable: false));
            AlterColumn("dbo.Course", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Course", "Descrpitipon", c => c.String(nullable: false));
            AlterColumn("dbo.Trainee", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Trainee", "Education", c => c.String(nullable: false));
            AlterColumn("dbo.Trainee", "DOB", c => c.String(nullable: false));
            AlterColumn("dbo.Trainee", "Age", c => c.String(nullable: false));
            AlterColumn("dbo.Trainee", "Department", c => c.String(nullable: false));
            AlterColumn("dbo.Trainee", "TOEIC", c => c.String(nullable: false));
            AlterColumn("dbo.Trainee", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Trainer", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Trainer", "Telephone", c => c.String(nullable: false));
            AlterColumn("dbo.Trainer", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Trainer", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Trainer", "WorkingPlace", c => c.String(nullable: false));
            AlterColumn("dbo.TrainingStaff", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.TrainingStaff", "Contact", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrainingStaff", "Contact", c => c.String());
            AlterColumn("dbo.TrainingStaff", "Name", c => c.String());
            AlterColumn("dbo.Trainer", "WorkingPlace", c => c.String());
            AlterColumn("dbo.Trainer", "Type", c => c.String());
            AlterColumn("dbo.Trainer", "Email", c => c.String());
            AlterColumn("dbo.Trainer", "Telephone", c => c.String());
            AlterColumn("dbo.Trainer", "Name", c => c.String());
            AlterColumn("dbo.Trainee", "Location", c => c.String());
            AlterColumn("dbo.Trainee", "TOEIC", c => c.String());
            AlterColumn("dbo.Trainee", "Department", c => c.String());
            AlterColumn("dbo.Trainee", "Age", c => c.String());
            AlterColumn("dbo.Trainee", "DOB", c => c.String());
            AlterColumn("dbo.Trainee", "Education", c => c.String());
            AlterColumn("dbo.Trainee", "Name", c => c.String());
            AlterColumn("dbo.Course", "Descrpitipon", c => c.String());
            AlterColumn("dbo.Course", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Descrpitipon", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
