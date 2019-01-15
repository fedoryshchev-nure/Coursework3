using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Coursework.API.DTOs;
using Coursework.API.Services.MaterialService;
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
        private readonly IMaterialService materialService;

        public AdminController(
            ISensorService sensorService, 
            IMaterialService materialService)
        {
            this.sensorService = sensorService;
            this.materialService = materialService;
        }

        [HttpPost]
        [ActionName("createSensors")]
        public async Task<ActionResult<IEnumerable<SensorDTO>>> CreateSensors(
            [FromBody]CreateWallDTO createWallDTO)
        {
            try
            {
                var sensors = await sensorService.CreateAsync(createWallDTO);

                return Ok(sensors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ActionName("attachWallToUser")]
        public async Task<IActionResult> AttachWallToUser([FromBody]UserWallDTO userWallDTO)
        {
            try
            {
                await sensorService.AttachWallToUser(userWallDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterial([FromBody]MaterialDTO materialDTO)
        {
            try
            {
                await materialService.CreateAsync(materialDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}