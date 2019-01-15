using Core.Entities.CrossTable;
using Core.Models;
using System.Collections.Generic;

namespace Core.Entities.Origin
{
    public class Material : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<WallMaterial> Walls { get; set; } = new List<WallMaterial>();
    }
}
