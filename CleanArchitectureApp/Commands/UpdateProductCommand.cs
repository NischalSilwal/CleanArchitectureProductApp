using CleanArchitectureApp.Application.DTOs;
using MediatR;

namespace CleanArchitectureApp.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; }
        public ProductDTO ProductDTO { get; }

        public UpdateProductCommand(int id, ProductDTO productDTO)
        {
            Id = id;
            ProductDTO = productDTO;
        }
    }
}
