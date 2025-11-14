using Feitep.MySql.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Feitep.MySql.Repository;

public class SistemaContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    public DbSet<Cliente>? Clientes { get; set; }

    public SistemaContext(DbContextOptions<SistemaContext>options)
    : base(options)

    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(cliente => cliente.Id);

            entity.Property(cliente => cliente.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

            entity.Property(Cliente => Cliente.Nome)
            .HasColumnName("nome")
            .HasMaxLength(255)
            .IsRequired();


            entity.Property(Cliente => Cliente.DataNascimento)
            .HasColumnName("dt_nascimento")
            .IsRequired();

        });
    }
}
