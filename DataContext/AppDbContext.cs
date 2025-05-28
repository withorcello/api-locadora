using Microsoft.EntityFrameworkCore;
using ApiLocadora.Entities;

namespace ApiLocadora.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Estudio> Estudios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>()
                .HasOne(filme => filme.Estudio)
                .WithMany(estudio => estudio.Filmes)
                .HasForeignKey(filme => filme.EstudioId);

            modelBuilder.Entity<Filme>()
                .HasOne(filme => filme.Genero)
                .WithMany(genero => genero.Filmes)
                .HasForeignKey(filme => filme.GeneroId);
        }
    }
}
