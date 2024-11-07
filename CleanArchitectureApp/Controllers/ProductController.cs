using CleanArchitectureApp.Application.Commands;
using CleanArchitectureApp.Application.DTOs;
using CleanArchitectureApp.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductDTO productDTO)
        {
            if (productDTO.ImageFile == null || productDTO.ImageFile.Length == 0)
            {
                return BadRequest("Image file is required.");
            }

            var productId = await _mediator.Send(new CreateProductCommand(productDTO));
            return Ok(productId); // Return created product Id
        }

        // Get All Products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());

            return Ok(products);
        }
    }
}
