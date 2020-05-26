using Microsoft.EntityFrameworkCore;

namespace TeledocTestProject.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Founder> Founders { get; set; }
        public DbSet<IndividualEntrepreneur> IndividualEntrepreneurs { get; set; }
        public DbSet<EntityClient> EntityClients { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
