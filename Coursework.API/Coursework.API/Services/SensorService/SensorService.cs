using AutoMapper;
using Core.Models.Origin;
using Coursework.API.DTOs;
using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework.API.Services.SensorService
{
    public class SensorService : ISensorService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public SensorService(IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task AttachToWallAsync(SensorDTO sensorDTO)
        {
            var sensor = await unitOfWork.Sensors.GetAsync(sensorDTO.Id);

            sensor.WallId = sensorDTO.WallId;

            await unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<SensorDTO>> CreateAsync(int amount)
        {
            var sensors = new List<Sensor>(amount);

            await unitOfWork.Sensors.AddRangeAsync(sensors);

            await unitOfWork.CompleteAsync();

            var sensorDTOs = mapper.Map<IEnumerable<SensorDTO>>(sensors);

            return await Task.FromResult(sensorDTOs);
        }

        public async Task PingAsync(SensorDTO sensorDTO)
        {
            if (await Authenticate(sensorDTO))
            {
                Sensor sensor = await unitOfWork.Sensors.GetAsync(sensorDTO.Id);

                sensor.IsBroken = sensorDTO.IsBroken;

                await unitOfWork.CompleteAsync();
            }
            else
                throw new Exception("Creds are not valid");
        }

        private async Task<bool> Authenticate(SensorDTO sensorDTO)
        {
            Sensor sensor = mapper.Map<Sensor>(sensorDTO);

            return (await unitOfWork.Sensors
                .GetAsync(sensorDTO.Id))?
                .Password == sensorDTO.Password;

        }
    }
}
