using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Price).HasPrecision(14, 2);

            //HasOne relacionamento 1 para muitos (1 categoria p muitos produtos) 
            //hasForeignKey vai gerar chave estrangeira para -> categorId 
            builder.HasOne(e => e.Category).WithMany(e => e.Products).HasForeignKey(e => e.CategoryId);
        }
    }
}
