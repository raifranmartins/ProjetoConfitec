using AutoMapper;
using ProConfitec.Application.DTOs;
using ProConfitec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Application.Mappings
{
    public class DtoToEntityMapping : Profile
    {
        public DtoToEntityMapping()
        {
            CreateMap<UserDTO, User>();
            CreateMap<ScholarityDTO, Scholarity>();
            CreateMap<UserDetailDTO, User>();
       }
    }
}
