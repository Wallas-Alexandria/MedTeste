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

        public async Task<Result<bool>> AdicionarContatoAsync(CriarContatoDTO contato)
        {
            var novoContato = Contato.CriarContato(contato.Nome, contato.DtNascimento, contato.Sexo);

            if (!novoContato.IsSuccess)
            {
                return Result<bool>.Failure(novoContato.Error);
            }

            _contatoRepository.Adicionar(novoContato.Data);
            await _contatoRepository.Commit();
            return Result<bool>.Success(true);
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

            var result = contatoExiste.AtualizarContato(contato.Nome, contato.DtNascimento, contato.Sexo);

            if (!result.IsSuccess)
            {
                return Result<bool>.Failure(result.Error);
            }

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

        public async Task<Result<ContatoDetalhesDTO>> PegarContatoPorIdAsync(Guid id)
        {
            var contato = await _contatoRepository.PegarPorIdAsync(id);

            if (contato ==  null)
            {
                return Result<ContatoDetalhesDTO>.Failure("Contato não encontrado!");
            }

            if (contato.Ativo == false)
            {
                return Result<ContatoDetalhesDTO>.Failure("Contato está inativo!");
            }

            var dto = ContatoDetalhesDTO.Map(contato);

            return Result<ContatoDetalhesDTO>.Success(dto);
        }

        public async Task<Result<List<ContatoDetalhesDTO>>> PegarTodosContatosAsync()
        {
            var contatos = await _contatoRepository.PegarTodosAtivosAsync();

            var listaContatos = contatos.Select(ContatoDetalhesDTO.Map).ToList();

            return Result<List<ContatoDetalhesDTO>>.Success(listaContatos);
        }


    }
}
