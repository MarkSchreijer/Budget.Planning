using System.ComponentModel.DataAnnotations.Schema;

namespace Budget.Planning.DataAccess.Models
{
    [Table("Valuta")]
    public class Valuta
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}