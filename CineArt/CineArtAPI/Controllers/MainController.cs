using CineArtBack.Fachada;
using Microsoft.AspNetCore.Mvc;

namespace CineArtAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private IData data;
        public MainController()
        {
            data = new DataLib();
        }

        [HttpPost("/login")]
        public IActionResult postLogin(string user, string password)
        {
            try
            {
                if (data.postLogin(user, password))
                {
                    return Ok("Login successful");
                }
                else
                {
                    return StatusCode(401, "Login failed");
                }   
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
    }
}
