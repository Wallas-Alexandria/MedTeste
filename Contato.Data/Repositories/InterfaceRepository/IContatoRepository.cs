using MedTeste.Domain.Entities;

namespace MedTeste.Data.Repositories.InterfaceRepository
{
    public interface IContatoRepository
    {
        Task<Contato> PegarPorIdAsync(Guid id);
        void Adicionar(Contato contato);
        void Atualizar(Contato contato);
        void Excluir(Contato contato);
        Task<List<Contato>> PegarTodosAtivosAsync();
        Task Commit();
    }
}
