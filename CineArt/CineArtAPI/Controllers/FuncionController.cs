using CineArtBack.Fachada;
using Microsoft.AspNetCore.Mvc;
using CineArtBack.Dominio;

namespace CineArtAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionController : ControllerBase
    {
        private IData data;
        public FuncionController()
        {
            data = new DataLib();
        }

        [HttpGet("/getFunciones")]
        public IActionResult getFunciones()
        {
            try
            {
                return Ok(data.getFunciones());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpGet("/getSalas")]
        public IActionResult getSalas()
        {
            try
            {
                return Ok(data.getSalas());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpPost("/postFuncion")]
        public IActionResult postFuncion(Funcion funcion)
        {
            try
            {
                return Ok(data.insertFuncion(funcion)); 
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpPut("/updateFuncion")]
        public IActionResult updateFuncion(int idFuncion, Funcion funcion)
        {
            try
            {
                return Ok(data.updateFuncion(idFuncion, funcion)); 
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpDelete("/deleteFuncion")]
        public IActionResult deleteFuncion(int idFuncion)
        {
            try
            {
                if (idFuncion == null)
                {
                    return BadRequest("Datos de funcion incorrectos!");
                }

                return Ok(data.deleteFuncion(idFuncion));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

    }
}
