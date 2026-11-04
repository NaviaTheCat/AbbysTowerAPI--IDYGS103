    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    namespace AbbysTowerAPI.Context
    {
        public class ApplicationDbContext : DbContext
        {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
        //MODELOS A MAPEAR
        public DbSet<Characters> Characters { get; set; }
        public DbSet<Levels> Levels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuraciones opcionales con Fluent API
        }
    }
    }
