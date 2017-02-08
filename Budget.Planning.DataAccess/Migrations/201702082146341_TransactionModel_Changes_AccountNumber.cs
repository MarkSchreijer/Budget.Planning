namespace Budget.Planning.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionModel_Changes_AccountNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "Account_Id", c => c.Int());
            AddColumn("dbo.Transaction", "ContraAccount_Id", c => c.Int());
            CreateIndex("dbo.Transaction", "Account_Id");
            CreateIndex("dbo.Transaction", "ContraAccount_Id");
            AddForeignKey("dbo.Transaction", "Account_Id", "dbo.AccountNumber", "Id");
            AddForeignKey("dbo.Transaction", "ContraAccount_Id", "dbo.AccountNumber", "Id");
            DropColumn("dbo.Transaction", "AccountNumberId");
            DropColumn("dbo.Transaction", "ContraAccountId");
            DropColumn("dbo.Transaction", "ToName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "ToName", c => c.String());
            AddColumn("dbo.Transaction", "ContraAccountId", c => c.String());
            AddColumn("dbo.Transaction", "AccountNumberId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transaction", "ContraAccount_Id", "dbo.AccountNumber");
            DropForeignKey("dbo.Transaction", "Account_Id", "dbo.AccountNumber");
            DropIndex("dbo.Transaction", new[] { "ContraAccount_Id" });
            DropIndex("dbo.Transaction", new[] { "Account_Id" });
            DropColumn("dbo.Transaction", "ContraAccount_Id");
            DropColumn("dbo.Transaction", "Account_Id");
        }
    }
}
