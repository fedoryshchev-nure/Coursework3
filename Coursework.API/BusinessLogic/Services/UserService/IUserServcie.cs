using System.Threading.Tasks;

namespace BusinessLogic.Services.UserService
{
    public interface IUserServcie
    {
        Task<bool> IsWallsOkayAsync(string email);
    }
}
