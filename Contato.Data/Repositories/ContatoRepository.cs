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
        public async Task AdicionarAsync(Contato contato)
        {
            await _context.Contatos.AddAsync(contato);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Contato contato)
        {
            var contatoExiste = _context.Contatos.Find(contato.Id);
            if (contatoExiste != null)
            {
                contatoExiste.Nome = contato.Nome;
                contatoExiste.DtNascimento = contato.DtNascimento;
                contatoExiste.Sexo = contato.Sexo;
                contatoExiste.Ativo = contato.Ativo;

                await _context.SaveChangesAsync();
            }
            else
            {
               throw new Exception("Contato não encontrado!");
            }
        }

        public async Task ExcluirAsync(Guid id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            if (contato != null)
            {
                _context.Contatos.Remove(contato);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Contato> PegarPorIdAsync(Guid id)
        {
            return await _context.Contatos.FindAsync(id);
        }

        public async Task<List<Contato>> PegarTodosAsync()
        {
            return await _context.Contatos.ToListAsync();
        }

        public async Task<List<Contato>> PegarTodosAtivosAsync()
        {
            return await _context.Contatos.Where(c => c.Ativo).ToListAsync();
        }
    }
}
