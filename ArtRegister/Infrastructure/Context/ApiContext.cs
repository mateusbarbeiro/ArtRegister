using Microsoft.EntityFrameworkCore;
using ArtRegister.Domain.Models;

namespace ArtRegister.Infrastructure.Context
{
    public partial class ApiContext : DbContext
    {
        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Sections> Sections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductsMapping());
            modelBuilder.ApplyConfiguration(new SectionMapping());
        }
    }
}
