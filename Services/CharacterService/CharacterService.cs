using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet_Rpg.Dtos.Character;
using Dotnet_Rpg.Models;

namespace Dotnet_Rpg.Services.CharacterService
{

  public class CharacterService : ICharacterService
  {
    private static List<Character> characters = new List<Character>
    {
        new Character{},
        new Character{Name="LAME",Strength=1000},
        new Character{Name="Lol",Class=RpgClass.Mage},
    };
    private readonly IMapper _mapper;

    public CharacterService(IMapper mapper)
    {
      _mapper = mapper;
    }
    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      Character character=_mapper.Map<Character>(newCharacter);
      character.Id = characters.Max(c => c.Id) + 1;
      characters.Add(character);
      serviceResponse.Data = characters.Select(c =>_mapper.Map<GetCharacterDto>(c)).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        serviceResponse.Data = characters.Select(c =>_mapper.Map<GetCharacterDto>(c)).ToList();
        serviceResponse.Message = "Successfully added a character to db";
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<GetCharacterDto>();
        serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
        return serviceResponse;
    }
  }
}