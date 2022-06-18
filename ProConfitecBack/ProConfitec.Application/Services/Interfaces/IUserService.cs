using ProConfitec.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<UserDTO>> CreateAsync(UserDetailDTO personDTO);
        Task<ResultService<ICollection<UserDetailDTO>>> GetAsync();
        Task<ResultService<UserDetailDTO>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(UserDTO personDTO);
        Task<ResultService> DeleteAsync(int id);        
    }
}
