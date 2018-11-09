using System.Threading.Tasks;

namespace BusinessLogic.Services.UserService
{
    public interface IUserServiсe
    {
        Task<bool> AreWallsOkayAsync(string email);
    }
}
