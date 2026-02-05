using MedTeste.Business.DTO;
using MedTeste.Domain.Entities;

namespace MedTeste.Business.Service.Interface
{
    public interface IContatoService
    {
        Task<List<Contato>> PegarTodosContatosAsync();
        Task<Result<bool>> PegarContatoPorIdAsync(Guid id);
        Task AdicionarContatoAsync(CriarContatoDTO contato);
        Task<Result<bool>> AtualizarContatoAsync(Guid id, EditarContatoDTO contato);
        Task<Result<bool>> ExcluirContatoAsync(Guid id);
        Task<Result<bool>> DesativarContatoAsync(Guid id);
    }
}
