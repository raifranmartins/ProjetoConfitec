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
    public class EntityToDtoMapping : Profile
    {
        public EntityToDtoMapping()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Scholarity, ScholarityDTO>();
            CreateMap<User, UserDetailDTO>()
                 .ConstructUsing((model, context) =>
                 {
                     var dto = new UserDetailDTO
                     {
                         Id = model.Id,
                         Name = model.Name,
                         Surname = model.Surname,
                         Email = model.Email,
                         BirthDate = model.BirthDate,
                         ScholarityId = model.ScholarityId,
                         SchoolRecordsId = model.SchoolRecordsId,
                         SchoolRecordsName = model.SchoolRecords.Name,
                         ScholarytyDescription = model.Scholarity.Description,
                         SchoolRecordsType = model.SchoolRecords.TypeFile
                     };

                     return dto;
                 });                
            
        }
    }
}
