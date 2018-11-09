using Data.UnitOfWork;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Services.UserService
{
    public class UserServiсe : IUserServiсe
    {
        private readonly IUnitOfWork unitOfWork;

        public UserServiсe(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> AreWallsOkayAsync(string email)
        {
            var sensors = (await unitOfWork.Users
                .GetWithWallsAndSensorsAsync(email))
                .Walls
                .SelectMany(x => x.WallSensors);
            var brokenSensorsCount =
                sensors.Count(x => x.IsBroken == true);

            return (double)brokenSensorsCount / sensors.Count() < 0.3;
        }
    }
}
