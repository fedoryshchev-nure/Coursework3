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
            var usersGroupedByRegions = users
                .GroupBy(x => x.Country)
                .Where(x => !string.IsNullOrEmpty(x.Key)).ToList();
            var orderedRegions = usersGroupedByRegions
                .OrderByDescending(x => x
                    .Average(k => k.Walls
                        .DefaultIfEmpty()
                        ?.Average(y => y
                            ?.WallSensors
                            ?.DefaultIfEmpty()
                            ?.Average(z => z?.DamageInPercents))))
                .Select(x => x.Key);

            return orderedRegions;
        }

        public IEnumerable<string> GetMostDamagedMaterials()
        {
            var walls = unitOfWork
                .Walls
                .GetAllWallsWithSensorsAndMaterials();
            var orderedMaterials = walls
                .GroupBy(x => x.Material.Name)
                .OrderByDescending(x => x
                        .Average(y => y
                            .WallSensors
                            .Average(z => z.DamageInPercents)))
                .Select(x => x.Key);

            return orderedMaterials;
        }
    }
}
