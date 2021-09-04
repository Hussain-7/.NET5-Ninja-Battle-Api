using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_Rpg.Dtos.Character;
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
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
    {
      return Ok(await _characterService.GetAllCharacter());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id) {
      return Ok(await _characterService.GetCharacterById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter) {
        return Ok(await _characterService.AddCharacter(newCharacter));
    }
  }
}