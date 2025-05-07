using Microsoft.AspNetCore.Mvc;
using ApiLocadora.Dtos;
using ApiLocadora.Services;

namespace ApiLocadora.Controllers
{
    [Route("filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeService _service;

        public FilmeController(FilmeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            var filmes = _service.Buscar();
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var filme = _service.BuscarPorId(id);

            return Ok(filme);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] FilmeDto item)
        {
            _service.Cadastrar(item);

            return Ok("Filme cadastrado com sucesso.");
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] FilmeDto item)
        {
            _service.Atualizar(id, item);

            return Ok("Filme atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _service.Remover(id);

            return Ok("Filme removido com sucesso!");
        }
    }
}
