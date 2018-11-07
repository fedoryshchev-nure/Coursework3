using Data.Repositories.Sensor;
using Data.Repositories.User;
using Data.Repositories.Wall;
using System;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; set; }
        IWallRepository Walls { get; set; }
        ISensorRepository Sensors { get; set; }

        Task CompleteAsync();
    }
}
