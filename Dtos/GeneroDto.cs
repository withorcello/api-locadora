using System.ComponentModel.DataAnnotations;

namespace ApiLocadora.Dtos
{
    public class GeneroDto
    {
        [Required]
        public required string Nome { get; set; }
    }
}
