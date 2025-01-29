using Microsoft.EntityFrameworkCore;
using XPe_Challenge.Models;

namespace XPe_Challenge.Data
{
    public class XPeDbContext : DbContext
    {
        public XPeDbContext(DbContextOptions<XPeDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}