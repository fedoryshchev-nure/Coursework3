using Core.Entities.Origin;
using System.Collections.Generic;

namespace Core.Models.Origin
{
    public class Wall : IEntity
    {
        public string Id { get; set; }

        public virtual IEnumerable<Sensor> WallSensors { get; set; } = new List<Sensor>();

        public string UserId { get; set; }
        public User User { get; set; }

        public string MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
