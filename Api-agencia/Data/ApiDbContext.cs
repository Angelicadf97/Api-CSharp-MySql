using Api_agencia.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_agencia.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
