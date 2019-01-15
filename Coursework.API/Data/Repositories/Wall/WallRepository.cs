using Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data.Repositories.Wall
{
    class WallRepository : GenericRepository<Core.Models.Origin.Wall>, IWallRepository
    {
        public WallRepository(ApplicationDBContext context) : base(context)
        {
        }

        public IEnumerable<Core.Models.Origin.Wall> GetAllWallsWithSensorsAndMaterials()
        {
            return Set
                .Include(x => x.Materials)
                    .ThenInclude(x => x.Material)
                .Include(x => x.WallSensors);
        }
    }
}
