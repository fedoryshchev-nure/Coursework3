using System.Collections.Generic;

namespace Core.Models.Origin
{
    public class Wall : Entity
    {
        public virtual IEnumerable<Sensor> WallSensors { get; set; } = new List<Sensor>();

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
