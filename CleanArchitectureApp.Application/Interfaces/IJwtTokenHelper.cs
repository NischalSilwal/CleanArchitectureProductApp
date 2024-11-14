using CleanArchitectureApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Interfaces
{
    public interface IJwtTokenHelper
    {
        public string GenerateToken(User user);
    }
}
