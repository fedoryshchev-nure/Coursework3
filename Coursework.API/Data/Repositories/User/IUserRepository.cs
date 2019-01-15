using Data.Repositories.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.User
{
    public interface IUserRepository : IGenericRepository<Core.Models.Origin.User>
    {
        IEnumerable<Core.Models.Origin.User> GetAllWithWallsAndSensors();
        Task<Core.Models.Origin.User> GetWithWallsAndSensorsAsync(string email);
        Task<Core.Models.Origin.User> GetByEmailAsync(string email);
    }
}
