using MedTeste.Business.DTO;
using MedTeste.Domain.Entities;

namespace MedTeste.Business.Service.Interface
{
    public interface IContatoService
    {
        Task<Result<List<ContatoDetalhesDTO>>> PegarTodosContatosAsync();
        Task<Result<ContatoDetalhesDTO>> PegarContatoPorIdAsync(Guid id);
        Task<Result<bool>> AdicionarContatoAsync(CriarContatoDTO contato);
        Task<Result<bool>> AtualizarContatoAsync(Guid id, EditarContatoDTO contato);
        Task<Result<bool>> ExcluirContatoAsync(Guid id);
        Task<Result<bool>> DesativarContatoAsync(Guid id);
    }
}
