using CleanArchitectureApp.Application.DTOs;
using CleanArchitectureApp.Application.Mappers;
using CleanArchitectureApp.Domain.Interfaces;
using CleanArchitectureApp.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureApp.Commands;

namespace CleanArchitectureApp.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _env;
        private readonly string _apiBaseUrl = "https://localhost:7288"; // Define API base URL here

        public UpdateProductHandler(IProductRepository productRepository, IWebHostEnvironment env)
        {
            _productRepository = productRepository;
            _env = env;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // Fetch the existing product
            var product = await _productRepository.GetProductByIdAsync(request.Id);
            if (product == null) return false;

            string fullImagePath = null;

            // Handle Image Update
            if (request.ProductDTO.ImageFile != null)
            {
                // Define the uploads folder inside wwwroot/UploadedImages
                var uploadsFolder = Path.Combine(_env.WebRootPath, "UploadedImages");
                Directory.CreateDirectory(uploadsFolder);

                // Generate a new unique file name
                var uniqueFileName = $"{Guid.NewGuid()}_{request.ProductDTO.ImageFile.FileName}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Delete the old image if it exists
                if (!string.IsNullOrEmpty(product.ImagePath))
                {
                    var oldImagePath = Path.Combine(_env.WebRootPath, product.ImagePath.TrimStart('/'));
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }

                // Save the new image file
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.ProductDTO.ImageFile.CopyToAsync(fileStream);
                }

                // Update the image path to include the full URL
                var relativePath = $"/UploadedImages/{uniqueFileName}";
                fullImagePath = $"{_apiBaseUrl}{relativePath}";
            }

            // Map updated properties from ProductDTO to Product entity
            ProductMapper.MapToUpdateProduct(request.ProductDTO, product, fullImagePath);

            // Update the product in the repository
            return await _productRepository.UpdateProductAsync(product);
        }
    }
}
