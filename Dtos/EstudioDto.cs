using System.ComponentModel.DataAnnotations;

namespace ApiLocadora.Dtos
{
    public class EstudioDto
    {
        [Required]
        public required string Nome { get; set; }
    }
}
