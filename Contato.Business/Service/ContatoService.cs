using MedTeste.Business.DTO;
using MedTeste.Business.Service.Interface;
using MedTeste.Data.Repositories.InterfaceRepository;
using MedTeste.Domain.Entities;

namespace MedTeste.Business.Service
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
        public async Task AdicionarContatoAsync(CriarContatoDTO contato)
        {
            var novoContato = Contato.CriarContato(contato.Nome, contato.DtNascimento, contato.Sexo);

            _contatoRepository.Adicionar(novoContato);
            await _contatoRepository.Commit();
        }

        public async Task<Result<bool>> DesativarContatoAsync(Guid id)
        {
            var contato = await _contatoRepository.PegarPorIdAsync(id);

            if (contato == null)
            {
                return Result<bool>.Failure("Contato não encontrado!");
            }

            contato.DesativarContato();
            await _contatoRepository.Commit();
            return Result<bool>.Success(true);
        }

        public async Task<Result<bool>> AtualizarContatoAsync(Guid id, EditarContatoDTO contato)
        {
            var contatoExiste = await _contatoRepository.PegarPorIdAsync(id);

            if (contatoExiste == null)
            {
                return Result<bool>.Failure("Contato não encontrado!");
            }

            contatoExiste.AtualizarContato(contato.Nome, contato.DtNascimento, contato.Sexo);
            await _contatoRepository.Commit();
            return Result<bool>.Success(true);
        }

        public async Task<Result<bool>> ExcluirContatoAsync(Guid id)
        {
            var contato = await _contatoRepository.PegarPorIdAsync(id);

            if (contato ==  null)
            {
                return Result<bool>.Failure("Contato não encontrado!");
            }

            _contatoRepository.Excluir(contato);
            await _contatoRepository.Commit();
            return Result<bool>.Success(true);
        }

        public async Task<Result<bool>> PegarContatoPorIdAsync(Guid id)
        {
            var contato = await _contatoRepository.PegarPorIdAsync(id);

            if (contato ==  null)
            {
                return Result<bool>.Failure("Contato não encontrado!");
            }

            if (contato.Ativo == false)
            {
                return Result<bool>.Failure("Contato está inativo!");
            }

            return Result<bool>.Success(true);
        }

        public async Task<List<Contato>> PegarTodosContatosAsync()
        {
            var contatos = await _contatoRepository.PegarTodosAtivosAsync();
            return contatos;
        }


    }
}
