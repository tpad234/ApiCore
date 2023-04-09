using Microsoft.AspNetCore.Mvc;
using Core;
using Microsoft.AspNetCore.Cors;
using Core.DTO;

namespace ApiCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GebruikerController : Controller
    {
        private readonly DatabaseContext _dataContext;
        public GebruikerController(DatabaseContext context)
        {
            _dataContext = context;
        }
        [EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetUser")]
        public List<GetGebruikerDTO> Get()
        {

            List<Gebruiker> gebruikers = fillgebruikers();

            List<GetGebruikerDTO> gebruikerDTOs = GebruikerTODTO(gebruikers);
            return gebruikerDTOs;
        }

        private List<GetGebruikerDTO> GebruikerTODTO(List<Gebruiker> gebruikers)
        {
            List<GetGebruikerDTO> gebruikerDTOs = new List<GetGebruikerDTO>();
            foreach (Gebruiker i in gebruikers)
            {
                GetGebruikerDTO gebruiker = new GetGebruikerDTO(i.Id, i.Naam, i.Email, i.Rol);
                gebruikerDTOs.Add(gebruiker);
            }
            return gebruikerDTOs;
        }
        private List<Gebruiker> fillgebruikers()
        {
            var gebruikers = _dataContext.gebruikers.ToList();

            return gebruikers;
        }
    }
}
