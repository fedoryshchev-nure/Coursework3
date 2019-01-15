using System.Collections.Generic;

namespace BusinessLogic.Services.StatisticService
{
    public interface IStatisticService
    {
        IEnumerable<string> GetRegionsOrderedByWallDamage();
        IEnumerable<string> GetMostDamagedMaterials();
    }
}
