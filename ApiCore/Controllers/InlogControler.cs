using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.DTO;

namespace ApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InlogControler : ControllerBase
    {
        private readonly DatabaseContext _dataContext;

        public InlogControler(DatabaseContext context)
        {
            _dataContext = context;
        }

        [EnableCors("AnotherPolicy")]
        [HttpPost (Name = "Checkinlog")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            var user = await _dataContext.gebruikers.SingleOrDefaultAsync(x => x.Email == request.Email && x.Wachtwoord == request.Wachtwoord);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(new { user.Id, user.Email }); // of andere data die je wilt terugsturen naar de client
        }

    }
}
