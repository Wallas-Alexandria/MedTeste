using MedTeste.Business.DTO;
using MedTeste.Business.Service.Interface;
using MedTeste.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedTeste.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;
        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }
        
        [HttpGet]
        public async Task<IActionResult> RetornarTodos()
        {
            var contatos = await _contatoService.PegarTodosContatosAsync();
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetornarPorId(Guid id)
        {
            var contato = await _contatoService.PegarContatoPorIdAsync(id);

            return Ok(contato);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] CriarContatoDTO contato)
        {
            await _contatoService.AdicionarContatoAsync(contato);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] EditarContatoDTO contato)
        {
            contato.Id = id;
            await _contatoService.AtualizarContatoAsync(contato);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            await _contatoService.ExcluirContatoAsync(id);
            return NoContent();

        }
    }
}
