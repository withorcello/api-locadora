using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiLocadora.Dtos;

namespace ApiLocadora.Controllers
{
    [Route("filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> listaFilmes = [ 
            new Filme() { 
                Nome = "Fast and Furious",
                Genero = "Action"
            },
            new Filme
            {
                Nome = "Fast and Furious II",
                Genero = "Action"
            },
            new Filme
            {
                Nome = "Fast and Furious - In Tokio",
                Genero = "Action"
            }
        ];

        [HttpGet]
        public IActionResult Buscar()
        {
            return Ok(listaFilmes);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] FilmeDto item)
        {
            var filme = new Filme();
            filme.Nome = item.Nome;
            filme.Genero = item.Genero;

            listaFilmes.Add(filme);

            return Ok(filme);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] FilmeDto item)
        {
            //Exemplo de NotFound
            if(id != Guid.NewGuid())
            {
                return NotFound();
            }

            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            return Ok();
        }
    }
}
