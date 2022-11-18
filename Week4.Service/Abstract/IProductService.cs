using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Data.Abstract;
using Week4.Data.DTOs;
using Week4.Domain.Entity;

namespace Week4.Service.Abstract
{
    public interface IProductService  
    {
        Task AddAsync(ProductDto productDto);
        Task Delete(int id);
        Task Update(ProductDto productDto, int id);
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetAsync(int id);
    }
}
