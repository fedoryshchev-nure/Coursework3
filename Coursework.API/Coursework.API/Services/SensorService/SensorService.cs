using AutoMapper;
using Core.Entities.CrossTable;
using Core.Entities.Origin;
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

        public async Task<IEnumerable<SensorDTO>> CreateAsync(CreateWallDTO dto)
        {
            var sensorDTOs = new List<SensorDTO>();

            var rnd = new Random();
            for (int i = 0; i < dto.SensorCount; ++i)
            {
                sensorDTOs.Add(new SensorDTO()
                {
                    Password = rnd
                        .Next(0, int.MaxValue)
                        .ToString()
                });
            }

            var wall = new Wall()
            {
                WallSensors = mapper.Map<IEnumerable<Sensor>>(sensorDTOs)
            };

            await unitOfWork.Walls.AddAsync(wall);

            wall.Materials = mapper
                .Map<IEnumerable<Material>>(dto.Materials)
                .Select(x => new WallMaterial() { MaterialId = x.Id, WallId = wall.Id });

            await unitOfWork.CompleteAsync();

            return await Task.FromResult(sensorDTOs);
        }

        public async Task<IEnumerable<WallDTO>> 
            GetWallsWithSensorsAndMaterialsForUser(string email)
        {
            var userWithWallAndSensors = await unitOfWork
                .Users
                .GetWithWallsAndSensorsAsync(email);
            var result = new List<WallDTO>();

            foreach(var wall in userWithWallAndSensors.Walls)
            {
                result.Add(
                    new WallDTO()
                    {
                        Id = wall.Id,
                        WallSensors = mapper.Map<IEnumerable<SensorDTO>>(wall.WallSensors),
                        Materials = mapper.Map<IEnumerable<MaterialDTO>>(wall.Materials)
                    });
            }

            return result;
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
                .PasswordHash == (int.Parse(sensorDTO.Password) % 13).ToString();

        }
    }
}
