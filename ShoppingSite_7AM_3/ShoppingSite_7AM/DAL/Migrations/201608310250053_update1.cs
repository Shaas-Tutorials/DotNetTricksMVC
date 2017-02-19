namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransactionDetails", "CartId", "dbo.Carts");
            DropForeignKey("dbo.TransactionDetails", "UserId", "dbo.Users");
            DropIndex("dbo.TransactionDetails", new[] { "UserId" });
            DropIndex("dbo.TransactionDetails", new[] { "CartId" });
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        Tran_Id = c.String(nullable: false, maxLength: 20, unicode: false),
                        Status = c.String(nullable: false, maxLength: 20, unicode: false),
                        PaymentType = c.String(maxLength: 20, unicode: false),
                        UserId = c.Int(nullable: false),
                        CartId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CartId);
            
            DropTable("dbo.TransactionDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TransactionDetails",
                c => new
                    {
                        TransactionDetailsId = c.Int(nullable: false, identity: true),
                        TransactionId = c.String(nullable: false, maxLength: 20, unicode: false),
                        Status = c.String(nullable: false, maxLength: 20, unicode: false),
                        PaymentType = c.String(maxLength: 20, unicode: false),
                        UserId = c.Int(nullable: false),
                        CartId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.TransactionDetailsId);
            
            DropForeignKey("dbo.Transactions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "CartId", "dbo.Carts");
            DropIndex("dbo.Transactions", new[] { "CartId" });
            DropIndex("dbo.Transactions", new[] { "UserId" });
            DropTable("dbo.Transactions");
            CreateIndex("dbo.TransactionDetails", "CartId");
            CreateIndex("dbo.TransactionDetails", "UserId");
            AddForeignKey("dbo.TransactionDetails", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.TransactionDetails", "CartId", "dbo.Carts", "CartId", cascadeDelete: true);
        }
    }
}
