using System.Collections.Generic;
using System.Linq;
using Dotnet_Rpg.Models;
using Dotnet_Rpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_Rpg.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CharacterController : ControllerBase
  {
    private readonly ICharacterService _characterService;
    public CharacterController(ICharacterService characterService) {
      _characterService = characterService;
    }
    //The ActionResult function enables us to send status codes back to the client with the requested data
    [HttpGet("all")]
    // [Route("GetAll")]
    public ActionResult<List<Character>> Get()
    {
      return Ok(_characterService.GetAllCharacter());
    }

    [HttpGet("{id}")]
    public ActionResult<Character> GetSingle(int id) {
      return Ok(_characterService.GetCharacterById(id));
    }

    [HttpPost]
    public ActionResult<List<Character>> AddCharacter(Character newCharacter) {
        return Ok(_characterService.AddCharacter(newCharacter));
    }
  }
}