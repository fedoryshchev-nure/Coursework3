using Data.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services.StatisticService
{
    public class StatisticService : IStatisticService
    {
        private readonly IUnitOfWork unitOfWork;

        public StatisticService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<string> GetRegionsOrderedByWallDamage()
        {
            var users = unitOfWork
                .Users
                .GetAllWithWallsAndSensors();
            var orderedRegions = users
                .GroupBy(x => x.Country)
                .OrderByDescending(x => x
                    .Average(k => k.Walls
                        .Average(y => y
                            .WallSensors
                            .Average(z => z.DamageInPercents))))
                .Select(x => x.Key);

            return orderedRegions;
        }

        public IEnumerable<string> GetMostDamagedMaterials()
        {
            var walls = unitOfWork
                .Walls
                .GetAllWallsWithSensorsAndMaterials();
            var orderedMaterials = walls
                .GroupBy(x => x.Materials
                    .Select(y => y.Material.Name))
                .OrderByDescending(x => x
                        .Average(y => y
                            .WallSensors
                            .Average(z => z.DamageInPercents)))
                .SelectMany(x => x.Key);

            return orderedMaterials;
        }
    }
}
