using ApiLocadora.DataContext;
using ApiLocadora.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var filme = new Filme();
            filme.Nome = item.Nome;
            filme.Genero = item.Genero;
            filme.DataLancamento = item.DataLancamento;

            _context.Filmes.Add(filme);
            _context.SaveChanges();
        }

        public void Atualizar(int id, FilmeDto item)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) throw new BadHttpRequestException("Filme não encontrado.");

            filme.Nome = item.Nome;
            filme.Genero = item.Genero;
            filme.DataLancamento = item.DataLancamento;

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
