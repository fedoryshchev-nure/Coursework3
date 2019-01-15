using Data.Repositories.Generic;

namespace Data.Repositories.Material
{
    public class MaterialRepository : GenericRepository<Core.Entities.Origin.Material>, IMaterialRepository
    {
        public MaterialRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
