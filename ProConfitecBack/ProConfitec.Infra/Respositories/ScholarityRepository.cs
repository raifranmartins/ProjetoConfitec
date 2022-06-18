using Microsoft.EntityFrameworkCore;
using ProConfitec.Domain.Entities;
using ProConfitec.Domain.Interfaces;
using ProConfitec.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Infra.Respositories
{
    public class ScholarityRepository : IScholarityRepository
    {

        private readonly PPContext _db;
        public ScholarityRepository(PPContext db)
        {
            _db = db;
        }
        public async Task<ICollection<Scholarity>> GetAllAsync()
        {
            return await _db.Scholarity.ToListAsync();
        }
    }
}
