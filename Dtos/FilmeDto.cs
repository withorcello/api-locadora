using System.ComponentModel.DataAnnotations;

namespace ApiLocadora.Dtos
{
    public class FilmeDto
    {
        [Required]
        public required string Nome { get; set; }

        [Required]
        public DateOnly DataLancamento { get; set; }

        [Required]
        public required int GeneroId { get; set; }

        [Required]
        public required int EstudioId { get; set; }
    }
}
