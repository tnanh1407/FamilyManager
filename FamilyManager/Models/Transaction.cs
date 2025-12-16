using SQLite;

namespace FamilyManager.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public decimal Amount { get; set; } // Số tiền
        public DateTime Date { get; set; }
        public string Note { get; set; } // Ghi chú

        public string Type { get; set; } // "Thu" hoặc "Chi"
        public string Category { get; set; } // "Điện nước", "Ăn uống"...
    }
}