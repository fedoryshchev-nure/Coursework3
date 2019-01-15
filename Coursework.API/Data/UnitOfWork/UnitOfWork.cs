using System.Threading.Tasks;
using Data.Repositories.Material;
using Data.Repositories.Sensor;
using Data.Repositories.User;
using Data.Repositories.Wall;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository Users { get; set; }
        public IWallRepository Walls { get; set; }
        public ISensorRepository Sensors { get; set; }
        public IMaterialRepository Materials { get; set; }

        private readonly ApplicationDBContext context;

        public UnitOfWork(ApplicationDBContext context)
        {
            this.context = context;
            Users = new UserRepository(context);
            Walls = new WallRepository(context);
            Sensors = new SensorRepository(context);
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
