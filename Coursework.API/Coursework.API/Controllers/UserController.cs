using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLogic.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.API.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserServiсe userServcie;

        public UserController(IUserServiсe userServcie)
        {
            this.userServcie = userServcie;
        }

        [HttpGet]
        [ActionName("state")]
        public async Task<ActionResult<bool>> State()
        {
            try
            {
                bool isOkey = await userServcie.AreWallsOkayAsync(
                    User.FindFirst(
                        ClaimTypes.Email)
                        ?.Value);

                return Ok(isOkey);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
