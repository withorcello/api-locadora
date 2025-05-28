using ApiLocadora.DataContext;
using ApiLocadora.Dtos;
using ApiLocadora.Entities;

namespace ApiLocadora.Services
{
    public class EstudioService
    {
        private readonly AppDbContext _context;

        public EstudioService(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<Estudio> Buscar()
        {
            return _context.Estudios.ToList();
        }

        public Estudio BuscarPorId(int id)
        {
            var estudio = _context.Estudios.FirstOrDefault(estudio => estudio.Id == id);
            if (estudio == null) throw new BadHttpRequestException("Estudio não encontrado.");

            return estudio;
        }

        public void Cadastrar(EstudioDto item)
        {
            var estudio = new Estudio(item.Nome);
            _context.Estudios.Add(estudio);

            _context.SaveChanges();
        }

        public void Atualizar(int id, EstudioDto item)
        {
            var estudio = _context.Estudios.FirstOrDefault(estudio => estudio.Id == id);
            if (estudio == null) throw new BadHttpRequestException("Estudio não encontrado.");

            estudio.Nome = item.Nome;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var estudio = _context.Estudios.FirstOrDefault(estudio => estudio.Id == id);
            if (estudio == null) throw new BadHttpRequestException("Estudio não encontrado.");

            _context.Estudios.Remove(estudio);
        }
    }
}
