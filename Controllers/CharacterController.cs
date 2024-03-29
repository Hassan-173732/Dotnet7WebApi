using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.CharacterDto;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Services.CharacterService;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {   
        private readonly ICharacterService _characterService; 
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
       

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
         return  Ok( await _characterService.GetAllCharacter());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetByID(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

         [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok( await _characterService.AddCharacter(newCharacter));
        }

          [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            return Ok( await _characterService.UpdateCharacter(updatedCharacter));
        }

    }
}