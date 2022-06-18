using AutoMapper;
using ProConfitec.Application.DTOs;
using ProConfitec.Application.Services.Interfaces;
using ProConfitec.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Application.Services
{
    public class ScholarityService : IScholarityService
    {

        private readonly IScholarityRepository _scholarityRepository;
        private readonly IMapper _mapper;

        public ScholarityService
            (
             IScholarityRepository scholarityRepository,
             IMapper mapper
            )
        {
            _scholarityRepository = scholarityRepository;
            _mapper = mapper;

        }

        public async Task<ResultService<ICollection<ScholarityDTO>>> GetAsync()
        {
            var scholarities = await _scholarityRepository.GetAllAsync();
            return ResultService.Ok<ICollection<ScholarityDTO>>(_mapper.Map<ICollection<ScholarityDTO>>(scholarities));
        }
    }
}
