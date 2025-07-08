using CleanArchitectureApp.Application.Services;
using CleanArchitectureApp.Commands;
using CleanArchitectureApp.Domain.Model;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductService _productService;
        private readonly string _imageUploadPath;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;

            // Set the upload path to the "wwwroot/UploadedImages" directory
            _imageUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages");
            // Ensure the directory exists
            if (!Directory.Exists(_imageUploadPath))
            {
                Directory.CreateDirectory(_imageUploadPath);
            }
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
          

                // Process the product image
                var fileName = $"{Guid.NewGuid()}_{request.ProductDTO.ImageFile.FileName}";
                var filePath = Path.Combine(_imageUploadPath, fileName);

                // Save the image to "wwwroot/UploadedImages"
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.ProductDTO.ImageFile.CopyToAsync(stream);
                }

                // Update to use the API's correct base URL
                var apiBaseUrl = "https://localhost:7114"; // API URL
                var relativePath = $"/UploadedImages/{fileName}";
                var fullImagePath = $"{apiBaseUrl}{relativePath}";

                // Create the product
                var product = new Product
                {
                    Name = request.ProductDTO.Name,
                    Price = request.ProductDTO.Price,
                    Description = request.ProductDTO.Description,
                    ImagePath = fullImagePath
                };

                // Add the product using the service
                var productId = await _productService.AddProductAsync(product);

   

                return productId;
            }
            catch (Exception ex)
            {
   
                throw new Exception("An error occurred while creating the product.", ex);
            }
        }
    }
}
