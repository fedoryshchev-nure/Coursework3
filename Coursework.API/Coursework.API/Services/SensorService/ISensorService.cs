using Coursework.API.DTOs;
using System.Threading.Tasks;

namespace Coursework.API.Services.SensorService
{
    public interface ISensorService
    {
        Task CreateAsync(SensorDTO sensorDTO);
        Task PingAsync(SensorDTO sensorDTO);
    }
}
