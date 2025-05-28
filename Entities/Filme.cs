using System.ComponentModel.DataAnnotations.Schema;

namespace ApiLocadora.Entities
{
    public class Filme(string nome, DateOnly dataLancamento, int generoId, int estudioId)
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = nome;

        [Column("data_lancamento")]
        public DateOnly DataLancamento { get; set; } = dataLancamento;

        [Column("genero_id")]
        public int GeneroId { get; set; } = generoId;

        [Column("estudio_id")]
        public int EstudioId { get; set; } = estudioId;

        public Genero? Genero { get; set; }

        public Estudio? Estudio { get; set; }
    }
}
