using MedTeste.Business.DTO;
using MedTeste.Business.Service.Interface;
using MedTeste.Business.Validacao;
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

        public async Task<Contato> AtivarDesativarContatoAsync(Guid id)
        {
            var contato = await _contatoRepository.PegarPorIdAsync(id);
            if (contato == null)
            {
                throw new Exception("Contato não encontrado!");
            }
            //contato.Ativo = !contato.Ativo;
            _contatoRepository.Atualizar(contato);
            await _contatoRepository.Commit();
            return contato;
        }

        public async Task AtualizarContatoAsync(Guid id, EditarContatoDTO contato)
        {
            var contatoExiste = await _contatoRepository.PegarPorIdAsync(id);

            if (contatoExiste == null)
            {
                throw new Exception("Contato não encontrado!");
            }

            contatoExiste.AtualizarContato(contato.Nome, contato.DtNascimento, contato.Sexo, contato.Ativo);

            await _contatoRepository.Commit();
        }

        public async Task ExcluirContatoAsync(Guid id)
        {
            var contato = await _contatoRepository.PegarPorIdAsync(id);

            if (contato == null)
            {
                throw new Exception("Contato não encontrado!");
            }

            _contatoRepository.Excluir(contato);
            await _contatoRepository.Commit();
        }

        public async Task<Contato> PegarContatoPorIdAsync(Guid id)
        {
            var contato = await _contatoRepository.PegarPorIdAsync(id);
            if (contato.Ativo == false)
            {
               throw new Exception("Contato está inativo!");
            }
            return contato;
        }

        public async Task<List<Contato>> PegarTodosContatosAsync()
        {
            var contatos = await _contatoRepository.PegarTodosAtivosAsync();
            return contatos;
        }


    }
}
