
using CleanArchitectureApp.Application.DTOs;
using CleanArchitectureApp.Application.Mappers;
using CleanArchitectureApp.Domain.Interfaces;
using CleanArchitectureApp.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<GetAllProductDTO>>
    {
        private readonly IProductRepository _productRepository;
    

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
          
        }

        /*
        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProductsAsync();
            /*
            return products.Select(product => new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImagePath = product.ImagePath
            }).ToList();

         //
            return ProductMapper.ToDto<IEnumerable<ProductDTO>>(products);
        }
        */
        public async Task<IEnumerable<GetAllProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProductsAsync();
            return ProductMapper.ToDto(products); // Now returns IEnumerable<GetAllProductDTO>
        }



    }
}
