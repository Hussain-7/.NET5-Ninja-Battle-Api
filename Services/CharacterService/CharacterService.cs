using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet_Rpg.Data;
using Dotnet_Rpg.Dtos.Character;
using Dotnet_Rpg.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Rpg.Services.CharacterService
{

  public class CharacterService : ICharacterService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public CharacterService(IMapper mapper, DataContext context)
    {
      _mapper = mapper;
      _context = context;
    }
    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      Character character = _mapper.Map<Character>(newCharacter);
      _context.Characters.Add(character);
      //To make the actual insert happen
      await _context.SaveChangesAsync();
      serviceResponse.Data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
      serviceResponse.Message = "Successfully added a character to db";
      return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      var dbCharacters = await _context.Characters.ToListAsync();
      serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
      var serviceResponse = new ServiceResponse<GetCharacterDto>();
      var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
      serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
      var serviceResponse = new ServiceResponse<GetCharacterDto>();
      try
      {
        Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
        Console.WriteLine(updatedCharacter);
        character.Name = updatedCharacter.Name;
        character.Hitpoints = updatedCharacter.Hitpoints;
        character.Strength = updatedCharacter.Strength;
        character.Defense = updatedCharacter.Defense;
        character.Intelligence = updatedCharacter.Intelligence;
        character.Class = updatedCharacter.Class;
        serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
        await _context.SaveChangesAsync();
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
        Character character = await _context.Characters.FirstAsync(c => c.Id == id);
        _context.Characters.Remove(character);
        await _context.SaveChangesAsync();
        serviceResponse.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
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
