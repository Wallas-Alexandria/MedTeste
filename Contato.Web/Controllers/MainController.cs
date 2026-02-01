using Microsoft.AspNetCore.Mvc;

namespace MedTeste.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MainController : ControllerBase
    {

        protected ActionResult CustomResponse(List<string> erros)
        {
            if (!erros.Any())
            {
                return Ok();
            }

            return BadRequest(new
            {
                success = false,
                errors = erros
            });
        }

        protected ActionResult CustomResponse(string mensagemErro)
        {
            return BadRequest(new
            {
                sucesso = false,
                notificacoes = new List<string> { mensagemErro }
            });
        }

        // Método para retornar sucesso
        protected ActionResult CustomResponse(object resultado = null)
        {
            return Ok(new
            {
                sucesso = true,
                dados = resultado
            });
        }
    }
}
