using Microsoft.AspNetCore.Mvc;
using ApiLocadora.Dtos;
using ApiLocadora.DataContext;

namespace ApiLocadora.Controllers
{
    [Route("filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FilmeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            var filmes = _context.Filmes.ToList();
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id, [FromBody] FilmeDto item)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound("Filme não encontrado.");

            return Ok(filme);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] FilmeDto item)
        {
            var filme = new Filme();
            filme.Nome = item.Nome;
            filme.Genero = item.Genero;

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return Ok("Filme cadastrado com sucesso.");
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] FilmeDto item)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound("Filme não encontrado.");

            filme.Nome = item.Nome;
            filme.Genero = item.Genero;

            return Ok("Filme atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound("Filme não encontrado.");

            _context.Filmes.Remove(filme);

            return Ok("Filme removido com sucesso!");
        }
    }
}
