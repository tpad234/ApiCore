using Core;
using Core.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
        public List<ItemDTO> Get()
        {

            List<ItemDTO> items = fillitems();
            return items;
        }
        private List<ItemDTO> fillitems()
        {
            return _dataContext.items.ToList();
            //GebruikerDTO gebruiker = new GebruikerDTO("testnaam2", "testmail2", "testwachtwoord2", Core.Enum.Rol.bezitter);
            //List<ItemDTO> items = new List<ItemDTO>
            //{
            //    new ItemDTO( "93jdl92ks", "testnaam", "testbeschrijbveing", gebruiker, Core.Enum.Status.bezit ),
            //    new ItemDTO( "43jdl92ks", "testnaam2", "testbeschrijbveing2", gebruiker, Core.Enum.Status.bezit  )

            //};
            //return items;
        }

        // GET api/<BezitController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
