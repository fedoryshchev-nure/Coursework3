using AutoMapper;
using Core.Models.Origin;
using Coursework.API.DTOs;
using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coursework.API.Services.SensorService
{
    public class SensorService : ISensorService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public SensorService(
            IMapper mapper,
            IUnitOfWork unitOfWork
            )
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task AttachWallToUser(UserWallDTO userWallDTO)
        {
            var user = await unitOfWork.Users.GetByEmailAsync(userWallDTO.Email);
            var wall = await unitOfWork.Walls.GetAsync(userWallDTO.WallId);
            
            wall.UserId = user.Id;

            await unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<SensorDTO>> CreateAsync(int amount)
        {
            var sensors = new List<Sensor>();

            var rnd = new Random();
            for (int i = 0; i < amount; ++i)
            {
                sensors.Add(new Sensor()
                {
                    Password = rnd
                        .Next(0, int.MaxValue)
                        .ToString()
                });
            }

            var wall = new Wall() { WallSensors = sensors };

            await unitOfWork.Walls.AddAsync(wall);

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
