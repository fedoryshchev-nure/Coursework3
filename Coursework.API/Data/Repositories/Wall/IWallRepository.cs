using Data.Repositories.Generic;
using System.Collections.Generic;

namespace Data.Repositories.Wall
{
    public interface IWallRepository : IGenericRepository<Core.Models.Origin.Wall>
    {
        IEnumerable<Core.Models.Origin.Wall> GetAllWallsWithSensorsAndMaterials();
    }
}
