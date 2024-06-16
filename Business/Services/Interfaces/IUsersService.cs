using Elpis.Data;
using Elpis.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elpis.Business.Services.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetUserAsync();
        Task<User?> GetUserByIdAsync(string id);
        Task<User> AddUser(User user);
        Task<string> GetCurrentUserId();
        Task DeleteAsync(User user);
        Task<User?> GetUserDataByUserId(string userId);
    }
}
