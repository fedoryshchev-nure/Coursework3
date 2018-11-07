using Data.Repositories.Generic;

namespace Data.Repositories.Sensor
{
    public class SensorRepository : GenericRepository<Core.Models.Origin.Sensor>, ISensorRepository
    {
        public SensorRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
