using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{   
    //attributes passes down to inherited controllers
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        
    }
}