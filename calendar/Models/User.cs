using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace calendar.Models

{
    public class User : IdentityUser
    {
        public virtual ICollection<Event> Events { get; set; }
    }
}
