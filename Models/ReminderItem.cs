namespace Reminders1.Models
{
    public class ReminderItem
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        //public bool IsComplete { get; set; }
        public DateTime EventDate { get; set; }
        public int? EventPriority { get; set; }
    }
}