using Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.User
{
    public class UserRepository : GenericRepository<Core.Models.Origin.User>, IUserRepository
    {
        public UserRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<Core.Models.Origin.User> GetAsync(string email, string pass)
        {
            return await set.FirstOrDefaultAsync(x => x.Email == email &&
                x.HashedPassword == pass);
        }

        public async Task<Core.Models.Origin.User> GetWithWallsAndSensorsAsync(string email)
        {
            return await set
                .Include(x => x.Walls)
                    .ThenInclude(x => x.WallSensors)
                .FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
