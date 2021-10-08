namespace ASM2.EF.FPTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCatId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Course", name: "Category_Id", newName: "Categories_Id");
            RenameIndex(table: "dbo.Course", name: "IX_Category_Id", newName: "IX_Categories_Id");
            AddColumn("dbo.Course", "CatId", c => c.Int(nullable: true));
            Sql("UPDATE dbo.Course SET CatId = 1 WHERE CatId IS NULL");
            AlterColumn("dbo.Course", "CatId", c => c.Int(nullable: false));

            CreateIndex("dbo.Course", "CatId");
            AddForeignKey("dbo.Course", "CatId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course", "CatId");
            RenameIndex(table: "dbo.Course", name: "IX_Categories_Id", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Course", name: "Categories_Id", newName: "Category_Id");
        }
    }
}
