using System.ComponentModel;

namespace Budget.Planning.DataAccess.Helpers
{
    public enum Valuta
    {
        Eur,
        Usd
    }

    public enum DebetCredit
    {
        Debet,
        Credit
    }

    public enum BookingCode
    {
        [Description("Acceptgiro")]
        Ac,
        [Description("Betaalautomaat")]
        Ba,
        [Description("Betalen contactloos")]
        Bc,
        [Description("Bankgiro opdracht")]
        Bg,
        [Description("Crediteuren betalen")]
        Cb,
        [Description("Chipknip")]
        Ck,
        [Description("Diverse boekingen")]
        Db,
        [Description("Bedrijven Euro-incasso")]
        Eb,
        [Description("Euro-incasso")]
        Ei,
        [Description("FiNBOX")]
        Fb,
        [Description("Geldautomaat Euro")]
        Ga,
        [Description("Geldautomaat VV")]
        Gb,
        [Description("iDeal")]
        Id,
        [Description("Kashandeling")]
        Kh,
        [Description("Machtiging")]
        Ma,
        [Description("Salaris betaling")]
        Sb,
        [Description("Eigen rekening")]
        Tb,
        [Description("Spoedbetaling")]
        Sp,
        [Description("Tegoed")]
        Cr,
        [Description("Tekort")]
        D
    }
}