using System.Threading.Tasks;
using Dotnet_Rpg.Dtos.Character;
using Dotnet_Rpg.Dtos.Weapon;
using Dotnet_Rpg.Models;
using Dotnet_Rpg.Services.WeaponService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_Rpg.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class WeaponController : ControllerBase
  {
    private readonly IWeaponService _weaponService;
    public WeaponController(IWeaponService weaponService)
    {
        _weaponService = weaponService;
    }
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddWeapon(AddWeaponDto newWeapon) {
      return Ok(await _weaponService.AddWeapon(newWeapon));
    }
  }
}