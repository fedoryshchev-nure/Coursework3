using Coursework.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coursework.API.Services.SensorService
{
    public interface ISensorService
    {
        Task<IEnumerable<SensorDTO>> CreateAsync(int amount);
        Task AttachToWallAsync(SensorDTO sensorDTO);
        Task PingAsync(SensorDTO sensorDTO);
    }
}
