using BusinessLogic.Services.StatisticService;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services.AutomatizationSerivce
{
    public class AutomatizationService : IAutomatizationService
    {
        private readonly IStatisticService statisticService;

        public AutomatizationService(IStatisticService statisticService)
        {
            this.statisticService = statisticService;
        }

        public IEnumerable<string> GetBestMaterials()
        {
            return statisticService
                .GetMostDamagedMaterials()
                .TakeLast(3)
                .Reverse();
        }

        public IEnumerable<string> GetBestRegions()
        {
            return statisticService
                .GetRegionsOrderedByWallDamage()
                .TakeLast(3)
                .Reverse();
        }
    }
}
