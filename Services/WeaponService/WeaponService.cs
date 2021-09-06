using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet_Rpg.Data;
using Dotnet_Rpg.Dtos.Character;
using Dotnet_Rpg.Dtos.Weapon;
using Dotnet_Rpg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Rpg.Services.WeaponService
{
  public class WeaponService : IWeaponService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public WeaponService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
      _context = context;
      _httpContextAccessor = httpContextAccessor;
      _mapper = mapper;

    }
    public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon)
    {
      var response = new ServiceResponse<GetCharacterDto>();
      try {
        var character = await _context.Characters
        .FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId &&
        c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
        if (character == null) { 
            response.Success = false;
            response.Message = "Character not found.";
            return response;
        }
        var Weapon = new Weapon
            {
                Name = newWeapon.Name,
                Damage=newWeapon.Damage,
                Character=character
            };
            _context.Weapons.Add(Weapon);
            await _context.SaveChangesAsync();
        response.Data = _mapper.Map<GetCharacterDto>(character);
      }catch (Exception e) { 
            response.Success= false;
            response.Message = e.Message;
      }
      return response;
    }
  }
}