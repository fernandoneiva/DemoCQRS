using DemoCQRS.Domain.Core.Aggregates;
using System.Data.Entity;

namespace DemoCQRS.Domain.Core
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<Fatura> Faturas { get; set; }
   
    }
}
