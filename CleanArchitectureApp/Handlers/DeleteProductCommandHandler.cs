using CleanArchitectureApp.Commands;
using CleanArchitectureApp.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureApp.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly string _imageUploadPath;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _imageUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages");

        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            // Retrieve the product to access the image path
            var product = await _productRepository.GetProductByIdAsync(request.Id);
            if (product == null) return false;

            // Get the image file path from the product's ImagePath
            var imagePath = Path.Combine(_imageUploadPath, Path.GetFileName(product.ImagePath));

            // Delete the image file if it exists
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            // Proceed to delete the product from the database
            return await _productRepository.DeleteProductAsync(request.Id);

        }
    }
}
