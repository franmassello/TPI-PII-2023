using CineArtBack.Fachada;
using Microsoft.AspNetCore.Mvc;
using CineArtBack.Dominio;

namespace CineArtAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ButacaController : ControllerBase
    {
        private IData data;
        public ButacaController()
        {
            data = new DataLib();
        }

        [HttpGet("/getButacasLibres")]
        public IActionResult getButacasLibres(int idFuncion)
        {
            try
            {
                return Ok(data.getButacasLibres(idFuncion));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpGet("/getButacasTotales")]
        public IActionResult getButacasTotales(int idFuncion)
        {
            try
            {
                return Ok(data.getButacasTotales(idFuncion));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpGet("/getButacasOcupadas")]
        public IActionResult getButacasOcupadas(int idFuncion)
        {
            try
            {
                return Ok(data.getButacasOcupadas(idFuncion));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

    }
}
