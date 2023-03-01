using Microsoft.AspNetCore.Mvc;
using Core;
using Core.DTO;
using Microsoft.AspNetCore.Cors;

namespace ApiCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GebruikerController : Controller
    {
        [EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetUser")]
        public List<GebruikerDTO> Get()
        {
          
        List<GebruikerDTO> gebruikers = fillgebruikers();
            return gebruikers;
        }
        private List<GebruikerDTO> fillgebruikers()
        {
            List<GebruikerDTO> gebruikers = new List<GebruikerDTO>
            {
                new GebruikerDTO( "testnaam", "testmail", "testwachtwoord", Core.Enum.Rol.bezitter ),
                new GebruikerDTO( "testnaam2", "testmail2", "testwachtwoord2", Core.Enum.Rol.bezitter )

            };
            return gebruikers;
        }
    }
}
