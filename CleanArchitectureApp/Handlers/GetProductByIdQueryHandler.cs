using CleanArchitectureApp.Application.DTOs;
using CleanArchitectureApp.Application.Mappers;
using CleanArchitectureApp.Domain.Interfaces;
using CleanArchitectureApp.Queries;
using MediatR;

namespace CleanArchitectureApp.Application.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdDTO>
    {
        private readonly IProductRepository _productRepository;
        
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        /*
        public Task<GetProductByIdDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetProductByIdAsync(request.Id);
            if (product == null) 
            {
                throw new Exception($"Product with ID {request.Id} not found.");
            }
            return ProductMapper.ToGetProductByIdDTO(product);
        }
        */
        public async Task<GetProductByIdDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);
            if (product == null)
            {
                throw new Exception($"Product with ID {request.Id} not found.");
            }
            return ProductMapper.ToGetProductByIdDTO(product);
        }


    }
}
