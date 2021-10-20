using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ArtRegister.Domain.Models;

namespace ArtRegister.Infrastructure.Context
{
    internal class ProductsMapping : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("products");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Active)
                .HasColumnName("active")
                .HasColumnType("tinyint(1)")
                .HasDefaultValueSql("'1'");

            builder.Property(e => e.CreatedDate)
                .HasColumnName("created_date")
                .HasColumnType("datetime")
                .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

            builder.Property(e => e.Deleted)
                .HasColumnName("deleted")
                .HasColumnType("tinyint(1)")
                .HasDefaultValueSql("'0'");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("description")
                .HasColumnType("varchar(200)");

            builder.Property(e => e.LastChange)
                .HasColumnName("last_change")
                .HasColumnType("datetime");

            builder.Property(e => e.Price)
                .HasColumnName("price")
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.SectionId)
                .HasColumnName("section_id");

            builder.HasOne(e => e.Section)
                .WithMany(i => i.Products)
                .HasForeignKey(e => e.SectionId);
        }
    }
}
