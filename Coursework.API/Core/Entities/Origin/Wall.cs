using Core.Entities.CrossTable;
using System.Collections.Generic;

namespace Core.Models.Origin
{
    public class Wall : IEntity
    {
        public string Id { get; set; }

        public virtual IEnumerable<Sensor> WallSensors { get; set; } = new List<Sensor>();

        public IEnumerable<WallMaterial> Materials { get; set; } = new List<WallMaterial>();

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
