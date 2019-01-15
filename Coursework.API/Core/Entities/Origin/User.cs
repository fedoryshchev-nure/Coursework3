using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Core.Models.Origin
{
    public class User : IdentityUser, IEntity 
    {
        public string Country { get; set; }

        public IEnumerable<Wall> Walls { get; set; } = new List<Wall>();
    }
}
