using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Domain.Interfaces;
using TODO.Domain.Models;

namespace TODO.Domain.Services
{
    public class AuthenticateUser
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateUser(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<User> Login(string name, string pass)
        {
            return await _userRepository.AuthenticateUserAsync(name, pass);
        }
    }
}
