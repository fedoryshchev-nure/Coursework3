using System.Collections.Generic;

namespace BusinessLogic.Services.AutomatizationSerivce
{
    public interface IAutomatizationService
    {
        IEnumerable<string> GetBestMaterials();
        IEnumerable<string> GetBestRegions();
    }
}
