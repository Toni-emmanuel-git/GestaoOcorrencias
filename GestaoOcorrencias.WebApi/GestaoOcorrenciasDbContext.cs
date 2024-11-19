using GestaoOcorrencias.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoOcorrencias.WebApi
{
    public class GestaoOcorrenciasDbContext : DbContext
    {
        public GestaoOcorrenciasDbContext()
        : base()
        {
            this.Database.Migrate();
        }

        public GestaoOcorrenciasDbContext(DbContextOptions options)
           : base(options)
        {
            this.Database.Migrate();
        }

        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<Ocorrencia> Ocorrencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
