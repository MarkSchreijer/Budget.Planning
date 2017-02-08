namespace Budget.Planning.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fill_MasterTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Valuta Values('Eur')");
            Sql("INSERT INTO Valuta Values('Usd')");

            Sql("INSERT INTO DebetCredit Values('Debet')");
            Sql("INSERT INTO DebetCredit Values('Credit')");

            Sql("INSERT INTO BookingCode Values('Acceptgiro', 'Ac')");
            Sql("INSERT INTO BookingCode Values('Betaalautomaat', 'Ba')");
            Sql("INSERT INTO BookingCode Values('Betalen contactloos', 'Bc')");
            Sql("INSERT INTO BookingCode Values('Bankgiro opdracht', 'Bg')");
            Sql("INSERT INTO BookingCode Values('Crediteuren betalen', 'Cb')");
            Sql("INSERT INTO BookingCode Values('Chipknip', 'Ck')");
            Sql("INSERT INTO BookingCode Values('Diverse boekingen', 'Db')");
            Sql("INSERT INTO BookingCode Values('Bedrijven Euro-incasso', 'Eb')");
            Sql("INSERT INTO BookingCode Values('Euro-incasso', 'Ei')");
            Sql("INSERT INTO BookingCode Values('FiNBOX', 'Fb')");
            Sql("INSERT INTO BookingCode Values('Geldautomaat Euro', 'Ga')");
            Sql("INSERT INTO BookingCode Values('Geldautomaat VV', 'Gb')");
            Sql("INSERT INTO BookingCode Values('iDeal', 'Id')");
            Sql("INSERT INTO BookingCode Values('Kashandeling', 'Kh')");
            Sql("INSERT INTO BookingCode Values('Machtiging', 'Ma')");
            Sql("INSERT INTO BookingCode Values('Salaris betaling', 'Sb')");
            Sql("INSERT INTO BookingCode Values('Eigen rekening','Tb')");
            Sql("INSERT INTO BookingCode Values('Spoedbetaling', 'Sp')");
            Sql("INSERT INTO BookingCode Values('Tegoed', 'Cr')");
            Sql("INSERT INTO BookingCode Values('Tekort', 'D')");
            }
        
        public override void Down()
        {
        }
    }
}
