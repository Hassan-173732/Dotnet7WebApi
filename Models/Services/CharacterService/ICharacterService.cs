using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.CharacterDto;

namespace Models.Services.CharacterService
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter();

         Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int Id);
         Task<ServiceResponse<AddCharacterDto>> AddCharacter(AddCharacterDto newCharacter);



    }
}