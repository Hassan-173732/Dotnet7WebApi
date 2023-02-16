using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Services.CharacterService
{
    public interface ICharacterService
    {
         List<Character> GetAllCharacter();

         Character GetCharacterById(int Id);
         Character AddCharacter(Character newCharacter);



    }
}