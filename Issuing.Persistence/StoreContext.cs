using Issuing.Domain;
using Issuing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Issuing.Persistence
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<Card> Cards { get; set; }
    }
}
