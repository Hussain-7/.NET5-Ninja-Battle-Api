using Dotnet_Rpg.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_Rpg.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CharacterController : ControllerBase
  {
    private static Character knight = new Character();

    

    [HttpGet]
    //This function enables us to send status codes back to the client with the requested data
    public ActionResult<Character> Get() 
    {
      return Ok(knight);
    }
  }
}