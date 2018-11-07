using AutoMapper;
using Core.Models.Origin;
using Coursework.API.DTOs;
using Data.UnitOfWork;
using System;
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

        public async Task CreateAsync(SensorDTO sensorDTO)
        {
            var sensor = mapper.Map<Sensor>(sensorDTO);

            await unitOfWork.Sensors.AddAsync(sensor);

            await unitOfWork.CompleteAsync();
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
