using SQLite;

namespace FamilyManager.Models
{
    [Table("Tasks")]
    public class AppTask
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; } // VD: Rửa bát
        public DateTime Deadline { get; set; } // Hạn chót
        public string Status { get; set; } // "Mới", "Đang làm", "Xong"

        public int AssignedMemberId { get; set; } // ID người làm
    }
}