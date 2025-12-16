using SQLite;

namespace MovieTicketApp.Models
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique]
        public string Email { get; set; } // Dùng Email làm tên đăng nhập
        public string FullName { get; set; }
        public string Password { get; set; } // Lưu ý: Thực tế nên mã hóa password trước khi lưu
    }
}