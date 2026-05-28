using Microsoft.EntityFrameworkCore;
using SoundBitesAPI.Models;

namespace SoundBitesAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Plato> Platos { get; set; } = null!;
    public DbSet<Categoria> Categorias { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("Categorias");
            entity.HasKey(e => e.IdCategoria);
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
        });

        modelBuilder.Entity<Plato>(entity =>
        {
            entity.ToTable("Platos");
            entity.HasKey(e => e.IdPlato);
            entity.Property(e => e.IdPlato).HasColumnName("id_plato");
            entity.Property(e => e.Nombre).HasColumnName("nombre").IsRequired();
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.HasOne<Categoria>().WithMany(c => c.Platos).HasForeignKey(p => p.IdCategoria);
        });
    }
}