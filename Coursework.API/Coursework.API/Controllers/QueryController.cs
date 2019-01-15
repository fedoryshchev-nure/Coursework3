using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLogic.Services.AutomatizationSerivce;
using BusinessLogic.Services.StatisticService;
using Coursework.API.DTOs;
using Coursework.API.Services.SensorService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.API.Controllers
{
    [Authorize(Roles = "User")]
    [Route("[controller]/[action]")]
    public class QueryController : Controller
    {
        private readonly ISensorService sensorService;
        private readonly IStatisticService statisticService;
        private readonly IAutomatizationService automatizationService;

        public QueryController(
            ISensorService sensorService, 
            IStatisticService statisticService, 
            IAutomatizationService automatizationService)
        {
            this.sensorService = sensorService;
            this.statisticService = statisticService;
            this.automatizationService = automatizationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WallDTO>>> GetWallsWithSensorForUser()
        {
            try
            {
                var res = await sensorService.GetWallsWithSensorsAndMaterialsForUser(
                    User.Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.Email)
                        .Value);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetRegionsOrderedByWallDamage()
        {
            try
            {
                var res = statisticService.GetRegionsOrderedByWallDamage();

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetMostDamagedMaterials()
        {
            try
            {
                var res = statisticService.GetMostDamagedMaterials();

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetBestMaterials()
        {
            try
            {
                var res = automatizationService.GetBestMaterials();

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetBestRegions()
        {
            try
            {
                var res = automatizationService.GetBestRegions();

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
