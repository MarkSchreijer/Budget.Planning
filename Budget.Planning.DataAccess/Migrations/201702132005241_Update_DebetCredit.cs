namespace Budget.Planning.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_DebetCredit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DebetCredit", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DebetCredit", "Code");
        }
    }
}
