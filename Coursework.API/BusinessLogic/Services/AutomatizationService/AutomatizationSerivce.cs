using BusinessLogic.Services.StatisticService;
using System.Collections.Generic;

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
                .TakeLast(3);
        }

        public IEnumerable<string> GetBestRegions()
        {
            return statisticService
                .GetRegionsOrderedByWallDamage()
                .TakeLast(3);
        }
    }
}
