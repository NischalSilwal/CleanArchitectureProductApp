using CleanArchitectureApp.Application.DTOs;
using CleanArchitectureApp.Domain.Model;

namespace CleanArchitectureApp.Application.Mappers
{
    public static class ProductMapper
    {
        public static Product MapToProduct(ProductDTO productDTO, string imagePath)
        {
            return new Product
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                Description = productDTO.Description,
                ImagePath = imagePath // Full image path including base URL
            };
        }
        /*
        public static UpdateroductDTO UpdateToDto(Product product)
        {
            if (product == null) return null;

            return new UpdateroductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImagePath = product.ImagePath
            };
        }

        */
        public static GetAllProductDTO ToDto(Product product)
        {
            return new GetAllProductDTO
            {
                Id = product.Id,  // Ensure you include Id mapping
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImagePath = product.ImagePath
            };
        }

        // Method to map a collection of Product to a collection of GetAllProductDTO
        public static IEnumerable<GetAllProductDTO> ToDto(IEnumerable<Product> products)
        {
            return products.Select(product => ToDto(product)).ToList(); // Correctly using the ToDto(Product) method
        }


    }
}

