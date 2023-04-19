using Core;
using Core.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VervoerController : ControllerBase
    {
        private readonly DatabaseContext _dataContext;
        public VervoerController(DatabaseContext context)
        {
            _dataContext = context;
        }
        [EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetVervoer")]
        public List<VervoerDTO> Get()
        {
            List<VervoerOpdrachten> Verzoeken = fillVerzoeken();

            List<VervoerDTO> gebruikerDTOs = verzoekToDTO(Verzoeken);

            return gebruikerDTOs;
        }
        private List<VervoerDTO> verzoekToDTO(List<VervoerOpdrachten> vervoerOpdrachten)
        {
            List<VervoerDTO> vervoerDTOs = new List<VervoerDTO>();
            foreach (VervoerOpdrachten i in vervoerOpdrachten)
            {
                GetGebruikerDTO ontvanger = new GetGebruikerDTO(i.Ontvanger.Id, i.Ontvanger.Naam, i.Ontvanger.Email, i.Ontvanger.Rol);
                GetGebruikerDTO verzender = new GetGebruikerDTO(i.Verzender.Id, i.Verzender.Naam, i.Verzender.Email, i.Verzender.Rol);
                ItemDTO item = new ItemDTO(i.Item.Id, i.Item.Code, i.Item.Naam, i.Item.Beschrijving, i.Item.EigenaarId, verzender, i.status);
                VervoerDTO vervoer = new VervoerDTO(i.Id, i.ItemId, item, i.VerzenderId, verzender, i.OntvangerId, ontvanger, i.status);


                vervoerDTOs.Add(vervoer);
            }
            return vervoerDTOs;
        }
        private List<VervoerOpdrachten> fillVerzoeken()
        {
            var verzoeken = _dataContext.verzoeken.Include(i => i.Item).Include(o => o.Ontvanger).Include(v => v.Verzender).ToList();

            return verzoeken;
        }
        // GET api/<VervoerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VervoerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VervoerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VervoerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
