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
        private readonly DatabaseContext _dataContext;
        public GebruikerController(DatabaseContext context)
        {
            _dataContext = context;
        }
        [EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetUser")]
        public List<GebruikerDTO> Get()
        {

            List<GebruikerDTO> gebruikers = fillgebruikers();
            return gebruikers;
        }
        private List<GebruikerDTO> fillgebruikers()
        {
            var gebruikers = _dataContext.gebruikers.ToList();

            return gebruikers;
        }
    }
}
