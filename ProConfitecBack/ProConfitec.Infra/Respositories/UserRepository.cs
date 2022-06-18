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
    public class UserRepository : IUserRepository
    {
        private readonly PPContext _db;
        public UserRepository(PPContext db)
        {
            _db = db;
        }

        public async Task<User> CreatAsync(User user)
        {
            _db.Add(user);
            await _db.SaveChangesAsync();

            return user;
        }

        public async Task DeleteAsync(User user)
        {
            _db.Remove(user);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(User user)
        {
            _db.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _db.Users.Include(x => x.SchoolRecords).Include(x => x.Scholarity).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _db.Users.Include(x => x.SchoolRecords).Include(x => x.Scholarity).ToListAsync();
        }
    }
}
