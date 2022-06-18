using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public class SchoolRecordRepository : ISchoolRecordRepository
    {
        private readonly PPContext _db;
        public SchoolRecordRepository(PPContext db)
        {
            _db = db;
        }

        public async Task<SchoolRecords> CreateRecordAsync(SchoolRecords record)
        {
            _db.Add(record);
            await _db.SaveChangesAsync();

            return record;
        }

        public async Task<SchoolRecords> DeleteRecordAsync(SchoolRecords record)
        {
            _db.Remove(record);
            await _db.SaveChangesAsync();
            return record;
        }

        public async Task<SchoolRecords> GetByIdAsync(int id)
        {
            return await _db.SchoolRecords.FirstOrDefaultAsync(x => x.Id == id);
        }


    }
}
