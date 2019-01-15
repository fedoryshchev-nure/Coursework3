using System.Collections.Generic;

namespace Coursework.API.DTOs
{
    public class CreateWallDTO
    {
        public int SensorCount { get; set; }
        public IEnumerable<MaterialDTO> Materials { get; set; }
    }
}
