using MedTeste.Business.DTO;
using MedTeste.Domain.Entities;

namespace MedTeste.Business.Service.Interface
{
    public interface IContatoService
    {
        Task<List<Contato>> PegarTodosContatosAsync();
        Task<Contato> PegarContatoPorIdAsync(Guid id);
        Task AdicionarContatoAsync(CriarContatoDTO contato);
        Task AtualizarContatoAsync(Guid id, EditarContatoDTO contato);
        Task ExcluirContatoAsync(Guid id);
        Task<Contato> AtivarDesativarContatoAsync(Guid id);
    }
}
