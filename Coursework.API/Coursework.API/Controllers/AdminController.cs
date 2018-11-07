using System;
using System.Threading.Tasks;
using Coursework.API.DTOs;
using Coursework.API.Services.SensorService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly ISensorService sensorService;

        public AdminController(ISensorService sensorService)
        {
            this.sensorService = sensorService;
        }

        [HttpPost]
        [ActionName("sensor")]
        public async Task<IActionResult> Sensor([FromBody]SensorDTO sensorDTO)
        {
            try
            {
                await sensorService.CreateAsync(sensorDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}