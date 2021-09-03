using System.Collections.Generic;
using System.Linq;
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
    public List<Character> AddCharacter(Character newCharacter)
    {
         characters.Add(newCharacter);
         return characters;
    }

    public List<Character> GetAllCharacter()
    {
        return characters;
    }

    public Character GetCharacterById(int id)
    {
        return characters.FirstOrDefault(c => c.Id == id);
    }
  }
}