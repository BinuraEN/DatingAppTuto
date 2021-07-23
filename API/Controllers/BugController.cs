using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BugController : BaseApiController
    {
        private readonly DataContext _context;
        public BugController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret(){
            return "secret text";
        }


        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound(){
            var thing = _context.Users.Find(-1); //something weknow that does not exist
            if(thing==null) return NotFound();
            return Ok(thing);
        }

     
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError(){
            var thing = _context.Users.Find(-1);
            var thingToReturn = thing.ToString(); //exception will occur since thing is null
            return thingToReturn;

        }


        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest(){
            return BadRequest("This was not a good request");
        }
    }
}