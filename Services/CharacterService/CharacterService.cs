using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_Rpg.Models;

namespace Dotnet_Rpg.Services.CharacterService
{
  public class CharacterService : ICharacterService
  {
    public static int Id = 0;
    private static List<Character> characters = new List<Character>
    {
        new Character{Id=Id++},
        new Character{Id=Id++,Name="Sam",Strength=1000},
        new Character{Id=Id++,Name="Sam",Class=RpgClass.Mage},
    };
    public async Task<List<Character>> AddCharacter(Character newCharacter)
    {
         characters.Add(newCharacter);
         return characters;
    }

    public async Task<List<Character>> GetAllCharacter()
    {
        return characters;
    }

    public async Task<Character> GetCharacterById(int id)
    {
        return characters.FirstOrDefault(c => c.Id == id);
    }
  }
}