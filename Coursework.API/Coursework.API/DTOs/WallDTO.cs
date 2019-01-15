using System.Collections.Generic;

namespace Coursework.API.DTOs
{
    public class WallDTO
    {
        public string Id { get; set; }

        public virtual IEnumerable<SensorDTO> WallSensors { get; set; }

        public IEnumerable<MaterialDTO> Materials { get; set; }
    }
}
