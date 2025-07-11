﻿using CleanArchitectureApp.Application.DTOs;
using CleanArchitectureApp.Application.Mappers;
using CleanArchitectureApp.Application.Services;
using CleanArchitectureApp.Domain.Interfaces;
using CleanArchitectureApp.Queries;
using MediatR;

namespace CleanArchitectureApp.Application.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdDTO>
    {
        private readonly IProductService _productService;

        public GetProductByIdQueryHandler(IProductService productService)
        {
            _productService = productService;
        }
        
        public async Task<GetProductByIdDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdAsync(request.Id);
            if (product == null)
            {
                throw new Exception($"Product with ID {request.Id} not found.");
            }
            return ProductMapper.ToGetProductByIdDTO(product);
        }


    }
}
