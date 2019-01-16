using Core.Models;
using Core.Models.Origin;
using System.Collections.Generic;

namespace Core.Entities.Origin
{
    public class Material : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Wall> Walls { get; set; } = new List<Wall>();
    }
}
