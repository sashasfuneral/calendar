using System;
using System.ComponentModel.DataAnnotations;

namespace calendar.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual Location Location { get; set; }
        public virtual User User { get; set; }
    }
}
