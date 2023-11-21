using CineArtBack.Fachada;
using Microsoft.AspNetCore.Mvc;
using CineArtBack.Dominio;

namespace CineArtAPI.Controllers
{
    //PeliculaController.cs
    // /getPeliculas
    // /getGeneros
    // /getIdiomas
    // /getFormatos
    // /insertPelicula
    // /updatePelicula
    // /deletePelicula


    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private IData data;
        public PeliculaController()
        {
            data = new DataLib();
        }

        [HttpGet("/getPeliculas")]
        public IActionResult getPeliculas()
        {
            try
            {
                return Ok(data.getComboPelicula());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpGet("/getGeneros")]
        public IActionResult getGeneros()
        {
            try
            {
                return Ok(data.getComboGenero());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpGet("/getIdiomas")]
        public IActionResult getIdiomas()
        {
            try
            {
                return Ok(data.getComboIdioma());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpGet("/getFormatos")]
        public IActionResult getFormatos()
        {
            try
            {
                return Ok(data.getComboFormato());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpPost("/insertPelicula")]
        public IActionResult PostProducto(Pelicula pelicula)
        {
            try
            {
                if (pelicula == null)
                {
                    return BadRequest("Datos de pelicula incorrectos!");
                }

                return Ok(data.getInsertPelicula(pelicula));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpPut("/updatePelicula")]
        public IActionResult updatePelicula(int idPelicula, Pelicula pelicula)
        {
            try
            {
                if (idPelicula == 0)
                {
                    return BadRequest("Numero de pelicula incorrecto!");
                }
                if (pelicula == null)
                {
                    return BadRequest("Datos de pelicula incorrectos!");
                }
                return Ok(data.getUpdatePelicula(idPelicula, pelicula));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }


        [HttpDelete("/deletePelicula")]
        public IActionResult DeletePelicula(int idPelicula)
        {
            try
            {
                if (idPelicula == 0)
                {
                    return BadRequest("Numero de pelicula incorrecto!");
                }
                return Ok(data.getDeletePelicula(idPelicula));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
    }
}
