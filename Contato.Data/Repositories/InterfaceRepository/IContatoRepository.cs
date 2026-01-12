using MedTeste.Domain.Entities;

namespace MedTeste.Data.Repositories.InterfaceRepository
{
    public interface IContatoRepository
    {
        Task<List<Contato>> PegarTodosAsync();
        Task<Contato> PegarPorIdAsync(Guid id);
        Task AdicionarAsync(Contato contato);
        Task AtualizarAsync(Contato contato);
        Task ExcluirAsync(Guid id);
        Task<List<Contato>> PegarTodosAtivosAsync();
    }
}
