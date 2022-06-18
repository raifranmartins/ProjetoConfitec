using ProConfitec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<ICollection<User>> GetAllAsync();
        Task<User> CreatAsync(User person);
        Task EditAsync(User person);
        Task DeleteAsync(User person);
    }
}
