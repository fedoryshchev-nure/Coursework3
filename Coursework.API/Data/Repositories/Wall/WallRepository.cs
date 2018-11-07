using Data.Repositories.Generic;

namespace Data.Repositories.Wall
{
    class WallRepository : GenericRepository<Core.Models.Origin.Wall>, IWallRepository
    {
        public WallRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
