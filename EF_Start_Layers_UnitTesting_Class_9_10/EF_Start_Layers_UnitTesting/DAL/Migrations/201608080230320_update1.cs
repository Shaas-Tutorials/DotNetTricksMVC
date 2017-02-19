namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "Category");
            AlterColumn("dbo.Category", "Name", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Category", "Name", c => c.String());
            RenameTable(name: "dbo.Category", newName: "Categories");
        }
    }
}
