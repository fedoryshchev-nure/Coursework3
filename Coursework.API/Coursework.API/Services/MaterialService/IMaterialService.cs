using Coursework.API.DTOs;
using System.Threading.Tasks;

namespace Coursework.API.Services.MaterialService
{
    public interface IMaterialService
    {
        Task CreateAsync(MaterialDTO materialDTO);
    }
}
