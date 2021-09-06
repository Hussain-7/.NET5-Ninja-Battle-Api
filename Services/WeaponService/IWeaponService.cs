using System.Threading.Tasks;
using Dotnet_Rpg.Dtos.Character;
using Dotnet_Rpg.Dtos.Weapon;
using Dotnet_Rpg.Models;

namespace Dotnet_Rpg.Services.WeaponService
{
    public interface IWeaponService
    {
     Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}