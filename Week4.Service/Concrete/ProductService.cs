using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Week4.Data.Abstract;
using Week4.Data.DTOs;
using Week4.Domain.Entity;
using Week4.Service.Abstract;

namespace Week4.Service.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task AddAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _repository.AddAsync(product);
        }

        public async Task Delete(int id)
        {
            var product = await _repository.GetAsync(id);
            if (product is null)
                throw new ArgumentException("Id not found");
            await _repository.Delete(id);
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            var productDto = _mapper.Map<List<ProductDto>>(products);
            return productDto;
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            var product = await _repository.GetAsync(id);
            if (product is null)
                throw new ArgumentException("Record is not found");
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task Update(ProductDto productDto, int id)
        {
          
            var updatedProduct = _mapper.Map<Product>(productDto);
            updatedProduct.Id = id;
                   await _repository.Update(updatedProduct);

        }
    }
}
