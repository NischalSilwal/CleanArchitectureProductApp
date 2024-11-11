﻿using CleanArchitectureApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);
        Task RegisterUserAsync(User user);
    }
}
