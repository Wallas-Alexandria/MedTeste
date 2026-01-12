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
            var resultado = ValidacaoContato.ValidarContato(contato);
            if (!resultado.IsValid)
            {
                throw new Exception(string.Join("; ", resultado.Erros));
            }
            var novoContato = new Contato
           {
               Nome = contato.Nome,
               DtNascimento = contato.DtNascimento,
               Sexo = contato.Sexo
           };

            await _contatoRepository.AdicionarAsync(novoContato);
        }

        public async Task<Contato> AtivarDesativarContatoAsync(Guid id)
        {
            var contato = await _contatoRepository.PegarPorIdAsync(id);
            if (contato == null)
            {
                throw new Exception("Contato não encontrado!");
            }
            contato.Ativo = !contato.Ativo;
            await _contatoRepository.AtualizarAsync(contato);
            return contato;
        }

        public async Task AtualizarContatoAsync(EditarContatoDTO contato)
        {

            var contatoExiste = await _contatoRepository.PegarPorIdAsync(contato.Id);
            var resultado = ValidacaoContato.ValidarContatoEditado(contato);

            if (!resultado.IsValid)
            {
                throw new Exception(string.Join("; ", resultado.Erros));
            }

            var contatoAtualizar = new Contato
            {
                Id = contato.Id,
                Nome = contato.Nome,
                DtNascimento = contato.DtNascimento,
                Sexo = contato.Sexo,
                Ativo = contato.Ativo
            };
            await _contatoRepository.AtualizarAsync(contatoAtualizar);
        }

        public async Task ExcluirContatoAsync(Guid id)
        {
            var contato = await _contatoRepository.PegarPorIdAsync(id);
            if (contato == null)
            {
                throw new Exception("Contato não encontrado!");
            }
            await _contatoRepository.ExcluirAsync(contato.Id);
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
