using MedTeste.Business.DTO;
using MedTeste.Business.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MedTeste.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            try
            {
                var contatos = await _contatoService.PegarTodosContatosAsync();
                return Ok(contatos);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetornarPorId(Guid id)
        {
            try
            {
                var contato = await _contatoService.PegarContatoPorIdAsync(id);

                return Ok(contato);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] CriarContatoDTO contato)
        {
            try
            {
                await _contatoService.AdicionarContatoAsync(contato);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest( new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] EditarContatoDTO contato)
        {
            try
            {
                await _contatoService.AtualizarContatoAsync(id, contato);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                await _contatoService.ExcluirContatoAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Desativar(Guid id)
        {
            try
            {
                await _contatoService.DesativarContatoAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

    }
}
