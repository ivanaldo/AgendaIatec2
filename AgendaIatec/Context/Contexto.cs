using AgendaIatec.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaIatec.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<UsuarioModel> UsuarioModels { get; set; }

        public DbSet<AgendaModel> AgendaModels { get; set; }

        public DbSet<ParticipantesModel> Participantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParticipantesModel>(entity =>
            {
                entity.HasKey(e => new { e.AgendaId, e.UsuarioId });
            });
        }

    }
}
