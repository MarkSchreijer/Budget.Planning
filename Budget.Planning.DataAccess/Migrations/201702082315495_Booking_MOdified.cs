namespace Budget.Planning.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking_MOdified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingCode", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingCode", "Code");
        }
    }
}
