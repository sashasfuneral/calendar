using Microsoft.AspNetCore.Http;
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

        public Event(IFormCollection form, Location location, User user)
        {
            User = user;
            Title = form["Event.Title"].ToString();
            Description = form["Event.Description"].ToString();
            StartTime = DateTime.Parse(form["Event.StartTime"].ToString());
            EndTime = DateTime.Parse(form["Event.EndTime"].ToString());
            Location = location;
        }
        public void UpdateEvent(IFormCollection form, Location location, User user)
        {
            User = user;
            Title = form["Event.Title"].ToString();
            Description = form["Event.Description"].ToString();
            StartTime = DateTime.Parse(form["Event.StartTime"].ToString());
            EndTime = DateTime.Parse(form["Event.EndTime"].ToString());
            Location = location;
        }
        public Event()
        {

        }
    }
}
