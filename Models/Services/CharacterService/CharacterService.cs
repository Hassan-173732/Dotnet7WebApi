using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Services.CharacterService
{
    
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{ Id = 1,Name = "Sam"}
        };

        public async Task<ServiceResponse<Character>> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            try
            {
                var response = new ServiceResponse<Character>{
                Data = characters,
                Success = true,
                Message = "Success"
            };
            return  response;
            }
            catch (System.Exception ex)
            {
                var response = new ServiceResponse<Character>{
                Data = null,
                Success = false,
                Message = ex.Message
            };
            return response;
            }
          

        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacter()
        {
           try
            {
                var response = new ServiceResponse<List<Character>>{
                Data = characters,
                Success = true,
                Message = "Success"
            };
            return  response;
            }
            catch (System.Exception ex)
            {
                var response = new ServiceResponse<List<Character>>{
                Data = null,
                Success = false,
                Message = ex.Message
            };
            return response;
            }
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int Id)
        {

            try
            {
                var character = characters.FirstOrDefault(x=> x.Id == Id);
                var response = new ServiceResponse<Character>{
                Data = character,
                Success = true,
                Message = "Success"
            };
            return  response;
            }
            catch (System.Exception ex)
            {
                var response = new ServiceResponse<Character>{
                Data = null,
                Success = false,
                Message = ex.Message
            };
            return response;
            }
          
        }
    }
}