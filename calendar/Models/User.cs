using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace calendar.Models

{
    public class User : IdentityUser
    {
        public static object FindFirstValue { get; internal set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
