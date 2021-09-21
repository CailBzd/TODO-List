using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TODO.Domain.Models;

namespace TODO.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(string iduser);
        Task<ICollection<User>> GetUsersAsync();
        Task<User> AuthenticateUserAsync(string name, string pass);
    }
}
