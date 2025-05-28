using ApiLocadora.DataContext;
using ApiLocadora.Dtos;
using ApiLocadora.Entities;

namespace ApiLocadora.Services
{
    public class GeneroService
    {
        private readonly AppDbContext _context;

        public GeneroService(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<Genero> Buscar()
        {
            return _context.Generos.ToList();
        }

        public Genero BuscarPorId(int id)
        {
            var genero = _context.Generos.FirstOrDefault(genero => genero.Id == id);
            if (genero == null) throw new BadHttpRequestException("Genero não encontrado.");

            return genero;
        }

        public void Cadastrar(GeneroDto item)
        {
            var genero = new Genero(item.Nome);
            _context.Generos.Add(genero);

            _context.SaveChanges();
        }

        public void Atualizar(int id, GeneroDto item)
        {
            var genero = _context.Generos.FirstOrDefault(genero => genero.Id == id);
            if (genero == null) throw new BadHttpRequestException("Genero não encontrado.");

            genero.Nome = item.Nome;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var genero = _context.Generos.FirstOrDefault(genero => genero.Id == id);
            if (genero == null) throw new BadHttpRequestException("Genero não encontrado.");

            _context.Generos.Remove(genero);
        }
    }
}
