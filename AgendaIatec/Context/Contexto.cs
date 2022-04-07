using AgendaIatec.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaIatec.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ParticipantesModel>()
            .HasOne(a => a.AgendaModel)
            .WithMany(p => p.ParticipantesModel)
            .HasForeignKey(ai => ai.AgendaId);

            modelBuilder.Entity<ParticipantesModel>()
            .HasOne(a => a.UsuarioModel)
            .WithMany(p => p.ParticipantesModel)
            .HasForeignKey(ai => ai.UsuarioId);
        }


        public DbSet<UsuarioModel> UsuarioModels { get; set; }

        public DbSet<AgendaModel> AgendaModels { get; set; }
        public DbSet<ParticipantesModel> ParticipantesModel { get; set; }

    }
}
