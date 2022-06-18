using ProConfitec.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Application.Services.Interfaces
{
    public interface IScholarityService
    {
        Task<ResultService<ICollection<ScholarityDTO>>> GetAsync();
    }
}
