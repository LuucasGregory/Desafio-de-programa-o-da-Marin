using Microsoft.AspNetCore.Mvc;

namespace Desafio.Marin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {
        [HttpPost]
        public IActionResult ProcessarArquivo(IFormFile file)
        {
            if (Path.GetExtension(file.FileName) != "cnab")
            {
                return BadRequest(new { Erro = "Arquivo no formato incorreto" });
            }

            return Ok();
        }
    }
}
