using System.Collections.Generic;
using System.Linq;
using Dotnet_Rpg.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_Rpg.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CharacterController : ControllerBase
  {
    public static int Id = 0;
    private static List<Character> characters = new List<Character>
    {
        new Character{Id=Id++},
        new Character{Id=Id++,Name="Sam",Strength=1000},
        new Character{Id=Id++,Name="Sam",Class=RpgClass.Mage},
    };

    //The ActionResult function enables us to send status codes back to the client with the requested data


    [HttpGet("all")]
    // [Route("GetAll")]
    public ActionResult<List<Character>> Get()
    {
      return Ok(characters);
    }

    [HttpGet("{id}")]
    public ActionResult<Character> GetSingle(int id) {
      return Ok(characters.FirstOrDefault(c => c.Id == id));
    }
  }
}