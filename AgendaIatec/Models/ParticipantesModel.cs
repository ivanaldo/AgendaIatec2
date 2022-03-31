namespace AgendaIatec.Models
{
    public class ParticipantesModel
    {
        public int Id { get; set; }
        public AgendaModel Agenda { get; set; }
        public UsuarioModel Usuario { get; set; }

    }
}
