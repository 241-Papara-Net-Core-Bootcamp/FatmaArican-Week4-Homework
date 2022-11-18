using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Data.Abstract;
using Week4.Domain.Entity;

namespace Week4.Data.Concrete
{
    public class ProductRepository : IProductRepository
    {

        private readonly IConfiguration _configuration;
        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(Product entity)
        {
            var sql = "Insert into Products (Name,Description,Category,Price) VALUES (@Name,@Description,@Category,@Price)";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }

        }
        public async Task<List<Product>> GetAllAsync()
        {
            var sql = "SELECT * FROM Products";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Product>(sql);
                return result.ToList();
            }
        }


        public async Task<Product> GetAsync(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> Update(Product entity)
        {
            var sql = "UPDATE Products SET Name = @Name, Description = @Description, Category = @Category, Price = @Price  WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
