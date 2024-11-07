using CleanArchitectureApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<GetAllProductDTO>> { }
}
