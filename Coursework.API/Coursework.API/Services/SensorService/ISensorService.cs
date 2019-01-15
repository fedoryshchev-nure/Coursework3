using Coursework.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coursework.API.Services.SensorService
{
    public interface ISensorService
    {
        Task<IEnumerable<SensorDTO>> CreateAsync(CreateWallDTO dto);
        Task AttachWallToUser(UserWallDTO userWallDTO);
        Task PingAsync(SensorDTO sensorDTO);
        Task<IEnumerable<WallDTO>> GetWallsWithSensorsAndMaterialsForUser(string email);
    }
}
