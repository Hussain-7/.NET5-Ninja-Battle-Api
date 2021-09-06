using AutoMapper;
using Dotnet_Rpg.Dtos.Character;
using Dotnet_Rpg.Dtos.Skill;
using Dotnet_Rpg.Dtos.Weapon;
using Dotnet_Rpg.Models;

namespace Dotnet_Rpg
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto,Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill, GetSkillDto>();
        }
    }
}