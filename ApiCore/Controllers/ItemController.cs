using Azure.Core.GeoJson;
using Core;
using Core.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
     
        private readonly DatabaseContext _dataContext;
        public ItemController(DatabaseContext context)
        {
            _dataContext = context;
        }
        // GET: api/<ItemController>
        [EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetItem")]
        public ActionResult<List<ItemDTO>> Get()
        {
            //hierdto van maken laten overzetten 
            List<Item> items = fillitems();

            List<ItemDTO> itemDTOs = new List<ItemDTO>();
            foreach (Item i in items)
            {
                GetGebruikerDTO gebruiker = new GetGebruikerDTO(i.Eigenaar.Id, i.Eigenaar.Naam, i.Eigenaar.Email, i.Eigenaar.Wachtwoord, i.Eigenaar.Rol);
                ItemDTO item = new ItemDTO(i.Id, i.Code,i.Naam ,i.Beschrijving, i.EigenaarId, gebruiker, i.status);
                itemDTOs.Add(item);
            }

            return itemDTOs;
        }
        private List<Item> fillitems()
        {
            var items = _dataContext.items.Include(i => i.Eigenaar).ToList();

            return items;

        }
        private List<Item> fillitems(int ID)
        {
            var items = _dataContext.items.Include(i => i.Eigenaar).Where(i => i.EigenaarId == ID).ToList();

            return items;

        }

        // GET api/<BezitController>/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name ="getitempergebruiker")]
        public List<ItemDTO> Get(int id)
        {
            List<Item> items = fillitems(id);
            List<ItemDTO> itemDTOs = new List<ItemDTO>();
            foreach (Item i in items)
            {
                GetGebruikerDTO gebruiker = new GetGebruikerDTO(i.Eigenaar.Id, i.Eigenaar.Naam, i.Eigenaar.Email, i.Eigenaar.Wachtwoord, i.Eigenaar.Rol);
                ItemDTO item = new ItemDTO(i.Id, i.Code, i.Naam, i.Beschrijving, i.EigenaarId, gebruiker, i.status);
                itemDTOs.Add(item);
            }
            return itemDTOs;
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
