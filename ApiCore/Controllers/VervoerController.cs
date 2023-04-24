using Core;
using Core.DTO;
using Core.Enum;
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
        [EnableCors("AnotherPolicy")]
        [HttpGet("GetVervoerMetVerzender")]
        public List<VervoerDTO> Get(int id)
        {
            List<VervoerOpdrachten> Verzoeken = fillVerzoeken();
            List<VervoerOpdrachten> Verzoekenuit = new List<VervoerOpdrachten>();
            foreach (VervoerOpdrachten v in Verzoeken)
            {
                if (v.Ontvanger.Id == id)
                {
                    Verzoekenuit.Add(v);
                }
            }

            List<VervoerDTO> gebruikerDTOs = verzoekToDTO(Verzoekenuit);

            return gebruikerDTOs;
        }

        // POST api/<VervoerController>
        [EnableCors("AnotherPolicy")]
        [HttpPost(Name = "postVervoer")]
        public IActionResult Post([FromBody] PostVervoerDTO vervoerDTO)
        {
            try
            {
                // Convert VervoerDTO to VervoerOpdrachten
                List<Item> Items = new List<Item>();
                VervoerOpdrachten vervoer = new VervoerOpdrachten();
                List<VervoerOpdrachten> vervoercheck = new List<VervoerOpdrachten>();
                vervoer.ItemId = vervoerDTO.ItemId;
                vervoer.VerzenderId = vervoerDTO.VerzenderId;
                vervoer.OntvangerId = vervoerDTO.OntvangerId;
                vervoer.status = Status.verzonden;
                vervoercheck = _dataContext.verzoeken.ToList();
                Items = _dataContext.items.ToList();


                foreach (VervoerOpdrachten v in vervoercheck)
                {
                    if (v.ItemId != vervoer.ItemId || v.VerzenderId != vervoer.VerzenderId || v.OntvangerId != vervoer.OntvangerId)
                    {
                        foreach (Item i in Items)
                        {
                            if (i.Id == vervoer.ItemId)
                            {
                                if (i.status == Status.bezit)
                                {
                                    i.status = Status.verzonden;

                                }
                                else
                                {
                                    throw new Exception("dit item is al verzonden");

                                }
                            }
                        }
                        _dataContext.verzoeken.Add(vervoer);
                        _dataContext.SaveChanges();

                    }
                    else
                    {
                        throw new Exception("dit item bestaat al ");

                    }
                }

                return Ok(new { vervoer.ItemId });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
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
