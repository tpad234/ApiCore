using Azure.Core.GeoJson;
using Core;
using Core.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Configuration;


namespace ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        // POST api/<BezitController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BezitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BezitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
