namespace AgendaIatec.DTO
{
    public class UsuarioDTO
    {
        public UsuarioDTO(int? id, string? nome, string? email, string? dataNascimento, string? senha, string? genero)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Senha = senha;
            Genero = genero;
        }

        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? DataNascimento { get; set; }
        public string? Senha { get; set; }
        public string? Genero { get; set; }
    }
}
