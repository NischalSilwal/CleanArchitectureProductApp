using CleanArchitectureApp.Domain.Interfaces;
using CleanArchitectureApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _UserRepository;
        public UserService(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            return await _UserRepository.Authenticate(username, password);
        }

        public async Task RegisterUserAsync(User user)
        {
           await _UserRepository.RegisterUserAsync(user);
          
        }
    }
}
