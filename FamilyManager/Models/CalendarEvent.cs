using SQLite;

namespace FamilyManager.Models
{
    [Table("Events")]
    public class CalendarEvent
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; } 
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
    }
}