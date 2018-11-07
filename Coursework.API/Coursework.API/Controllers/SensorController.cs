using System;
using System.Threading.Tasks;
using Coursework.API.DTOs;
using Coursework.API.Services.SensorService;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.API.Controllers
{
    [Route("[controller]")]
    public class SensorController : Controller
    {
        private readonly ISensorService sensorService;

        public SensorController(ISensorService sensorService)
        {
            this.sensorService = sensorService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SensorDTO dto)
        {
            try
            {
                await sensorService.PingAsync(dto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}