namespace Budget.Planning.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MasterTables_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingCode",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DebetCredit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Valuta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Transaction", "BookingCode_Id", c => c.Int());
            AddColumn("dbo.Transaction", "DebitCredit_Id", c => c.Int());
            AddColumn("dbo.Transaction", "Valuta_Id", c => c.Int());
            CreateIndex("dbo.Transaction", "BookingCode_Id");
            CreateIndex("dbo.Transaction", "DebitCredit_Id");
            CreateIndex("dbo.Transaction", "Valuta_Id");
            AddForeignKey("dbo.Transaction", "BookingCode_Id", "dbo.BookingCode", "Id");
            AddForeignKey("dbo.Transaction", "DebitCredit_Id", "dbo.DebetCredit", "Id");
            AddForeignKey("dbo.Transaction", "Valuta_Id", "dbo.Valuta", "Id");
            DropColumn("dbo.Transaction", "Valuta");
            DropColumn("dbo.Transaction", "DebitCredit");
            DropColumn("dbo.Transaction", "BookingCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "BookingCode", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction", "DebitCredit", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction", "Valuta", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transaction", "Valuta_Id", "dbo.Valuta");
            DropForeignKey("dbo.Transaction", "DebitCredit_Id", "dbo.DebetCredit");
            DropForeignKey("dbo.Transaction", "BookingCode_Id", "dbo.BookingCode");
            DropIndex("dbo.Transaction", new[] { "Valuta_Id" });
            DropIndex("dbo.Transaction", new[] { "DebitCredit_Id" });
            DropIndex("dbo.Transaction", new[] { "BookingCode_Id" });
            DropColumn("dbo.Transaction", "Valuta_Id");
            DropColumn("dbo.Transaction", "DebitCredit_Id");
            DropColumn("dbo.Transaction", "BookingCode_Id");
            DropTable("dbo.Valuta");
            DropTable("dbo.DebetCredit");
            DropTable("dbo.BookingCode");
        }
    }
}
