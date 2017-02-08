namespace Budget.Planning.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedAccountNumberToAccount : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AccountNumber", newName: "Account");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Account", newName: "AccountNumber");
        }
    }
}
