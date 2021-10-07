namespace ASM2.EF.FPTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainer", "Name", c => c.String(nullable: true));
            Sql("UPDATE dbo.Trainer SET Name = 'Viet' WHERE Name IS NULL");
            AlterColumn("dbo.Trainer", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainer", "Name");
        }
    }
}
