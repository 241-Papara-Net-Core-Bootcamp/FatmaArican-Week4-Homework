using Microsoft.EntityFrameworkCore;
using Week4.Domain.Entity;

namespace Week4.Data.Context
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }
        public DbSet<Product> Product { get; set; }
    }
}
