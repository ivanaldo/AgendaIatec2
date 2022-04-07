namespace AgendaIatec.Models
{
    public class ParticipantesModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioModel UsuarioModel { get; set; }

        public int AgendaId { get; set; }
        public AgendaModel AgendaModel { get; set; }

    }
}
