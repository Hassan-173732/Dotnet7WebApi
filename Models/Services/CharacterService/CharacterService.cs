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
            new Character(),
            new Character{ Id = 2,Name = "Sam"}
        };

        public async Task<ServiceResponse<AddCharacterDto>> AddCharacter(AddCharacterDto newCharacter)
        {
            characters.Add(_mapper.Map<Character>(newCharacter));
            try
            {
                var response = new ServiceResponse<AddCharacterDto>{
                Data = newCharacter,
                Success = true,
                Message = "Success"
            };
            return  response;
            }
            catch (System.Exception ex)
            {
                var response = new ServiceResponse<AddCharacterDto>{
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
    }
}