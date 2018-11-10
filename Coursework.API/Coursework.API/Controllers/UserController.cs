using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLogic.Services.UserService;
using Core.Models.Origin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.API.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserServiсe userServcie;
        private readonly UserManager<User> userManager;

        public UserController(
            UserManager<User> userManager,
            IUserServiсe userServcie)
        {
            this.userManager = userManager;
            this.userServcie = userServcie;
        }

        [HttpGet]
        [ActionName("state")]
        public async Task<ActionResult<bool>> State()
        {
            try
            {
                bool isOkey = await userServcie.AreWallsOkayAsync(
                    User.Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.Email)
                        .Value);

                return Ok(isOkey);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
