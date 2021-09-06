using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet_Rpg.Data;
using Dotnet_Rpg.Dtos.Character;
using Dotnet_Rpg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Rpg.Services.CharacterService
{

  public class CharacterService : ICharacterService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CharacterService(IMapper mapper, DataContext context,IHttpContextAccessor httpContextAccessor)
    {
      _mapper = mapper;
      _context = context;
      _httpContextAccessor = httpContextAccessor;
    }
    private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      Character character = _mapper.Map<Character>(newCharacter);
      character.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
      _context.Characters.Add(character);
      //To make the actual insert happen
      await _context.SaveChangesAsync();
      serviceResponse.Data = await _context.Characters
      .Where(c=>c.User.Id== GetUserId())
      .Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
      serviceResponse.Message = "Successfully added a character to db";
      return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
    {

      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      var dbCharacters = await _context.Characters.Where(c=>c.User.Id == GetUserId()).ToListAsync();
      serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
      var serviceResponse = new ServiceResponse<GetCharacterDto>();
      var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id && c.User.Id==GetUserId());
      serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
      var serviceResponse = new ServiceResponse<GetCharacterDto>();
      try
      {
        Character character = await _context.Characters
        .Include(c => c.User)
        .FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
        if (character.User.Id == GetUserId())
        { 
          character.Name = updatedCharacter.Name;
          character.Hitpoints = updatedCharacter.Hitpoints;
          character.Strength = updatedCharacter.Strength;
          character.Defense = updatedCharacter.Defense;
          character.Intelligence = updatedCharacter.Intelligence;
          character.Class = updatedCharacter.Class;
          await _context.SaveChangesAsync();
          serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
        }
        else
        {
          serviceResponse.Success = false;
          serviceResponse.Message = "Character not found";
        }
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      try
      {
        Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id && c.User.Id==GetUserId());
        if (character != null) { 
            _context.Characters.Remove(character);
             await _context.SaveChangesAsync();

             serviceResponse.Data = _context.Characters.Where(c=>c.User.Id == GetUserId()).Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        }
        else { 
          serviceResponse.Success=false;
          serviceResponse.Message = "Character not found.";
        }

      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }
      return serviceResponse;
    }
  }
}
