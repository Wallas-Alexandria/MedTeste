using MedTeste.Data.Context;
using MedTeste.Data.Repositories.InterfaceRepository;
using MedTeste.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedTeste.Data.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AppDbContext _context;
        public ContatoRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Adicionar(Contato contato)
        {
             _context.Contatos.Add(contato);
        }

        public void Atualizar(Contato contato)
        {
            _context.Contatos.Update(contato);
        }

        public void Excluir(Contato contato)
        {
            _context.Contatos.Remove(contato);
        }

        public async Task<Contato> PegarPorIdAsync(Guid id)
        {
            return await _context.Contatos.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Contato>> PegarTodosAtivosAsync()
        {
            return await _context.Contatos.Where(c => c.Ativo).ToListAsync();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

    }
}
