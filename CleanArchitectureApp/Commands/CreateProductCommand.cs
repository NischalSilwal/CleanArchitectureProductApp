using CleanArchitectureApp.Application.DTOs;
using CleanArchitectureApp.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public ProductDTO ProductDTO { get; }

        public CreateProductCommand(ProductDTO productDTO)
        {
            ProductDTO = productDTO;
        }
    }


}
