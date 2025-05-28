using ApiLocadora.DataContext;
using ApiLocadora.Dtos;
using ApiLocadora.Entities;

namespace ApiLocadora.Services
{
    public class FilmeService
    {
        private readonly AppDbContext _context;

        public FilmeService(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<Filme> Buscar()
        {
            return _context.Filmes.ToList();
        }

        public Filme BuscarPorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) throw new BadHttpRequestException("Filme não encontrado.");

            return filme;
        }

        public void Cadastrar(FilmeDto item)
        {
            var filme = new Filme(item.Nome, item.DataLancamento, item.GeneroId, item.EstudioId);
            _context.Filmes.Add(filme);

            _context.SaveChanges();
        }

        public void Atualizar(int id, FilmeDto item)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) throw new BadHttpRequestException("Filme não encontrado.");

            filme.Nome = item.Nome;
            filme.DataLancamento = item.DataLancamento;
            filme.GeneroId = item.GeneroId;
            filme.EstudioId = item.EstudioId;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) throw new BadHttpRequestException("Filme não encontrado.");

            _context.Filmes.Remove(filme);
        }
    }
}
