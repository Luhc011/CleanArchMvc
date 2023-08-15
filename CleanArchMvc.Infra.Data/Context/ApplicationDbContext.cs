using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            foreach (var item in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) item.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(builder);
        }

    }

}

