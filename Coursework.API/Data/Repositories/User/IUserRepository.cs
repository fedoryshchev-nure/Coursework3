using Data.Repositories.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.User
{
    public interface IUserRepository : IGenericRepository<Core.Models.Origin.User>
    {
        Task<Core.Models.Origin.User> GetAsync(string email, string pass);
        Task<Core.Models.Origin.User> GetWithWallsAndSensorsAsync(string email);
    }
}
