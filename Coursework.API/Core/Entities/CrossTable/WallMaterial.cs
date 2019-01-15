using Core.Entities.Origin;
using Core.Models.Origin;

namespace Core.Entities.CrossTable
{
    public class WallMaterial
    {
        public string WallId { get; set; }
        public Wall Wall { get; set; }

        public string MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
