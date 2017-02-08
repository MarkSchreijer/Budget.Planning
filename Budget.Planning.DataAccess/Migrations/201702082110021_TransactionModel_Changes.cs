namespace Budget.Planning.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionModel_Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "ToName", c => c.String());
            AlterColumn("dbo.Transaction", "ContraAccountId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "ContraAccountId", c => c.Int(nullable: false));
            DropColumn("dbo.Transaction", "ToName");
        }
    }
}
