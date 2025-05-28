namespace ApiLocadora.Entities
{
    public class Genero(string nome)
    {
        public int Id { get; set; }
        public string Nome { get; set; } = nome;
        public ICollection<Filme> Filmes { get; set; } = new List<Filme>();
    }
}
