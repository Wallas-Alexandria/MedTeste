using MedTeste.Business.DTO;
using MedTeste.Business.Service.Interface;
using MedTeste.Domain.Entities;
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
              var contatos = await _contatoService.PegarTodosContatosAsync();
              return Ok(contatos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetornarPorId(Guid id)
        {
            var result = await _contatoService.PegarContatoPorIdAsync(id);

            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Error });
            }
            return Ok(result);

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
            var result = await _contatoService.AtualizarContatoAsync(id, contato);

            if (!result.IsSuccess)
            {
                return BadRequest(new {message = result.Error});
            }
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var result = await _contatoService.ExcluirContatoAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Error });
            }
            return NoContent();

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Desativar(Guid id)
        {
            var result = await _contatoService.DesativarContatoAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Error });
            }
            return NoContent();

        }

    }
}
