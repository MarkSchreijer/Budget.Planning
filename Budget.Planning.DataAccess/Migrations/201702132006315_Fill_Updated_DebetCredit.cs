namespace Budget.Planning.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fill_Updated_DebetCredit : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE DebetCredit SET Code='C' WHERE Description='Credit'");
            Sql("UPDATE DebetCredit SET Code='D' WHERE Description='Debet'");
        }
        
        public override void Down()
        {
        }
    }
}
