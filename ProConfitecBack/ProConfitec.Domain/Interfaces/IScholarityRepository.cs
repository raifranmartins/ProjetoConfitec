using ProConfitec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Domain.Interfaces
{
    public interface IScholarityRepository
    {
        Task<ICollection<Scholarity>> GetAllAsync();
    }
}
