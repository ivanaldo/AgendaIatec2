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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
