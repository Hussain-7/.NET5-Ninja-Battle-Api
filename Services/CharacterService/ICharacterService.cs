using System.Collections.Generic;
using Dotnet_Rpg.Models;

namespace Dotnet_Rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        List<Character> GetAllCharacter();
        Character GetCharacterById(int id);
        List<Character> AddCharacter(Character newCharacter);
  }
}