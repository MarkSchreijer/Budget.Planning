namespace Budget.Planning.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountNumber",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumberId = c.Int(nullable: false),
                        Valuta = c.Int(nullable: false),
                        InterestDate = c.DateTime(nullable: false),
                        DebitCredit = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContraAccountId = c.Int(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        BookingCode = c.Int(nullable: false),
                        Filler = c.String(),
                        Description1 = c.String(),
                        Description2 = c.String(),
                        Description3 = c.String(),
                        Description4 = c.String(),
                        Description5 = c.String(),
                        Description6 = c.String(),
                        EndToEndId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transaction");
            DropTable("dbo.AccountNumber");
        }
    }
}
