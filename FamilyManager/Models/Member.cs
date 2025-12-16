using SQLite;

namespace FamilyManager.Models
{
    [Table("Members")]
    public class Member
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; } // Bố, Mẹ, Con...
        public string AvatarPath { get; set; }
    }
}