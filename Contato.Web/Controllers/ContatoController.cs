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
        [ProducesResponseType(typeof(List<ContatoDetalhesDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RetornarTodos()
        {
            var result = await _contatoService.PegarTodosContatosAsync();

            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Error });
            }
              return Ok(result.Data);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContatoDetalhesDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RetornarPorId(Guid id)
        {
            var result = await _contatoService.PegarContatoPorIdAsync(id);

            if (!result.IsSuccess)
            {
                if (result.Error.Contains("não encontrado"))
                {
                    return NotFound(new { message = result.Error });
                }
                return BadRequest(new { message = result.Error });
            }
            return Ok(result.Data);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Adicionar([FromBody] CriarContatoDTO contato)
        {
            var result = await _contatoService.AdicionarContatoAsync(contato);

            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Error });
            }

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
