using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Week4.Data.DTOs;
using Week4.Domain.Entity;
using Week4.Service.Abstract;

namespace Week4.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var productList = await _productService.GetAllAsync();
            return Ok(productList);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetAsync(id);
            return Ok(product);

        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto entity)
        { 
            await _productService.AddAsync(entity);
            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDto entity, int id)
        {

            await _productService.Update(entity, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        { 
           await   _productService.Delete(id);
            return Ok();
        }
    }
}
