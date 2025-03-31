using Domain.Entities;
using Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class NegocioConfig : IEntityTypeConfiguration<Negocio>
    {
        public void Configure(EntityTypeBuilder<Negocio> builder)
        {
            builder.ToTable("negocio");

            builder.Property(x => x.nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.direccion)
                .HasMaxLength(100);

            builder.Property(x => x.telefono)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(x => x.descripcion)
                .HasMaxLength(1024);

            builder.Property(x => x.tipo)
                .IsRequired();

            builder.Property(x => x.estado)
                .IsRequired();



            // Configuración de la relación con ApplicationUser
            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey("EmprendedorId")
                .IsRequired(false); // Ajusta según tus necesidades

            // Configuración de la relación muchos a muchos con vendedores
            builder.HasMany<ApplicationUser>()
                .WithMany()
                .UsingEntity(j => j.ToTable("NegocioVendedores"));

            builder.HasMany(x => x.NegocioClientes)
               .WithOne(x => x.Negocio)
               .HasForeignKey(x => x.NegocioId);

            builder.HasMany(x => x.Promociones)
              .WithOne()
              .HasForeignKey("NegocioId");

            builder.HasOne(n => n.Categoria) // Usa la propiedad de navegación
                .WithMany()
                .HasForeignKey(n => n.CategoriaId)
                .IsRequired(true);
        }
    }
}