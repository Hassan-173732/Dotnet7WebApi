using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Services.CharacterService
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<Character>>> GetAllCharacter();

         Task<ServiceResponse<Character>> GetCharacterById(int Id);
         Task<ServiceResponse<Character>> AddCharacter(Character newCharacter);



    }
}