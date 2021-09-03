using System.Collections.Generic;
using System.Threading.Tasks;
using Dotnet_Rpg.Models;

namespace Dotnet_Rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAllCharacter();
        Task<Character> GetCharacterById(int id);
        Task<List<Character>> AddCharacter(Character newCharacter);
  }
}