using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities.Origin;
using Coursework.API.DTOs;
using Data.UnitOfWork;

namespace Coursework.API.Services.MaterialService
{
    public class MaterialService : IMaterialService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MaterialService(
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateAsync(MaterialDTO materialDTO)
        {
            var material = mapper.Map<Material>(materialDTO);

            await unitOfWork.Materials.AddAsync(material);

            await unitOfWork.CompleteAsync();
        }

        public IEnumerable<MaterialDTO> GetAll()
        {
            var materials = unitOfWork
                .Materials
                .GetAll()
                .Result;

            return mapper.Map<IEnumerable<MaterialDTO>>(materials);
        }
    }
}
