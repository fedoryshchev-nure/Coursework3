using System.Collections.Generic;

namespace Core.Models.Origin
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Wall> Walls { get; set; } = new List<Wall>();
    }
}
