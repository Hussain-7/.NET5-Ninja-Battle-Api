using System;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_Rpg.Data;
using Dotnet_Rpg.Dtos.Fight;
using Dotnet_Rpg.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Rpg.Services.FightService
{
	public class FightService : IFightService
	{
		private readonly DataContext _context;
		public FightService(DataContext context)
		{
			_context = context;
		}

		public async Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto request)
		{
					var response = new ServiceResponse<AttackResultDto>();
				try {
					var attacker = await _context.Characters
					.Include(c => c.Skills)
					.FirstOrDefaultAsync(c => c.Id == request.AttackerId);

					var opponent = await _context.Characters
					.FirstOrDefaultAsync(c => c.Id == request.OpponentId);

				var skill = attacker.Skills.FirstOrDefault(s => s.Id == request.SkillId);
				if (skill==null)
				{
					response.Success = false;
					response.Message = $"{attacker.Name} doesn't know how to perform this Skill.";
					return response;
				}
					int damage = skill.Damage + (new Random().Next(attacker.Intelligence));
					damage -= new Random().Next(opponent.Defense);

					if (damage > 0)
						opponent.Hitpoints -= damage;

					if (opponent.Hitpoints < 0)
						response.Message = $"{opponent.Name} has been defeated";

					await _context.SaveChangesAsync();


					response.Data = new AttackResultDto
					{
						AttackerName = attacker.Name,
						AttackerHP = attacker.Hitpoints,
						OpponentName = opponent.Name,
						OpponentHP = opponent.Hitpoints,
						Damage = damage,
					};
				}
				catch (Exception e) {
					response.Success = false;
					response.Message =e.Message;
				}
				return response;
		}
		

		public async Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request)
		{
			var response = new ServiceResponse<AttackResultDto>();
			try {
				var attacker = await _context.Characters
				.Include(c => c.Weapon)
				.FirstOrDefaultAsync(c => c.Id == request.AttackerId);

				var opponent = await _context.Characters
				.FirstOrDefaultAsync(c => c.Id == request.OpponentId);

				int damage = attacker.Weapon.Damage + (new Random().Next(attacker.Strength));
				damage -= new Random().Next(opponent.Defense);

				if (damage > 0)
					opponent.Hitpoints -= damage;

				if (opponent.Hitpoints < 0)
					response.Message = $"{opponent.Name} has been defeated";

				await _context.SaveChangesAsync();


				response.Data = new AttackResultDto
				{
					AttackerName = attacker.Name,
					AttackerHP = attacker.Hitpoints,
					OpponentName = opponent.Name,
					OpponentHP = opponent.Hitpoints,
					Damage = damage,
				};
			}
			catch (Exception e) {
				response.Success = false;
				response.Message =e.Message;
			}
			return response;
		}
	}
}