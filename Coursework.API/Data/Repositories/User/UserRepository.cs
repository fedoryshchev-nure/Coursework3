using Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.User
{
    public class UserRepository : GenericRepository<Core.Models.Origin.User>, IUserRepository
    {
        public UserRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<Core.Models.Origin.User> GetByEmailAsync(string email)
        {
            return await Set.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Core.Models.Origin.User> GetWithWallsAndSensorsAsync(string email)
        {
            return await Set
                .Include(x => x.Walls)
                    .ThenInclude(x => x.WallSensors)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public IEnumerable<Core.Models.Origin.User> GetAllWithWallsAndSensors()
        {
            return Set
                .Include(x => x.Walls)
                    .ThenInclude(x => x.WallSensors);
        }
    }
}
