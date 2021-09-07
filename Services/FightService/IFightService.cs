using System.Collections.Generic;
using System.Threading.Tasks;
using Dotnet_Rpg.Dtos.Fight;
using Dotnet_Rpg.Models;

namespace Dotnet_Rpg.Services.FightService
{
    public interface IFightService
    {
		Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request);
		Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto request);
		Task<ServiceResponse<FightResultDto>> Fight(FightRequestDto request);
		Task<ServiceResponse<List<HighScoreDto>>> GetHighScore();
	}
}