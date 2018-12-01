using System;
using System.Collections.Generic;
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

        [HttpGet("{amount}")]
        [ActionName("sensor")]
        public async Task<ActionResult<IEnumerable<SensorDTO>>> Sensor(int amount)
        {
            try
            {
                var sensors = await sensorService.CreateAsync(amount);

                return Ok(sensors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost()]
        [ActionName("attachToWall")]
        public async Task<IActionResult> AttachToWall(SensorDTO sensorDTO)
        {
            try
            {
                await sensorService.AttachToWallAsync(sensorDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}