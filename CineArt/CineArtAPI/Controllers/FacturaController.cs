using CineArtBack.Fachada;
using Microsoft.AspNetCore.Mvc;
using CineArtBack.Dominio;

namespace CineArtAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private IData data;
        public FacturaController()
        {
            data = new DataLib();
        }

        [HttpGet("/getFactura")]
        public IActionResult getFactura()
        {
            try
            {
                return Ok(data.getFacturas()); // TO DO FRAN
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpPost("/insertFactura")]
        public IActionResult insertFactura(Factura factura)
        {
            try
            {
                return Ok(data.insertFactura(factura)); // TO DO FRAN
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpPut("/updateFactura")]
        public IActionResult updateFactura(int idFactura, Factura factura)
        {
            try
            {
                return Ok(data.updateFactura(idFactura, factura)); // TO DO FRAN
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpDelete("/deleteFactura")]
        public IActionResult deleteFactura(int idFactura)
        {
            try
            {
                return Ok(data.deleteFactura(idFactura)); // TO DO FRAN
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

       
    }
}
