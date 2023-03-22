using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dtos.CharacterDto;

namespace Models.Services.CharacterService
{
    
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        private static List<Character> characters = new List<Character>{
            new Character{Id = 1},
            new Character{ Id = 2,Name = "Sam"}
        };

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter)
        {
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            try
            {
                var response = new ServiceResponse<GetCharacterDto>{
                Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == character.Id)),
                Success = true,
                Message = "Success"
            };
            return  response;
            }
            catch (System.Exception ex)
            {
                var response = new ServiceResponse<GetCharacterDto>{
                Data = null,
                Success = false,
                Message = ex.Message
            };
            return response;
            }
          

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
        {
           try
            {
                var response = new ServiceResponse<List<GetCharacterDto>>{
                Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList(),
                Success = true,
                Message = "Success"
            };
            return  response;
            }
            catch (System.Exception ex)
            {
                var response = new ServiceResponse<List<GetCharacterDto>>{
                Data = null,
                Success = false,
                Message = ex.Message
            };
            return response;
            }
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int Id)
        {

            try
            {
                var character = characters.FirstOrDefault(x=> x.Id == Id);
                var response = new ServiceResponse<GetCharacterDto>{
                Data = _mapper.Map<GetCharacterDto>(character),
                Success = true,
                Message = "Success"
            };
            return  response;
            }
            catch (System.Exception ex)
            {
                var response = new ServiceResponse<GetCharacterDto>{
                Data = null,
                Success = false,
                Message = ex.Message
            };
            return response;
            }
          
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
            var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

            if(character != null)
            {
            character.Name = updatedCharacter.Name;
            character.HitPoints = updatedCharacter.HitPoints;
            character.Defense = updatedCharacter.Defense;
            character.Class = updatedCharacter.Class;
            character.Intelligence = updatedCharacter.Intelligence;
            character.Strength = updatedCharacter.Strength;
            
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Character Not Found!";
            }
            
            return  serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return  serviceResponse;
            }
            
        }
    }
}