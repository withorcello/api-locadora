using System.ComponentModel.DataAnnotations.Schema;

namespace ApiLocadora
{
    public class Filme
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("genero")]
        public string Genero { get; set; }

        [Column("data_lancamento")]
        public DateOnly DataLancamento { get; set; }
    }
}
