using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {   

        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{ Id = 1,Name = "Sam"}
        };


        [HttpGet]
        public ActionResult<List<Character>> Get()
        {
         return  Ok(characters);
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetByID(int id)
        {
            return Ok(characters.FirstOrDefault(x => x.Id == id));
        }

         [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return Ok(characters);
        }

    }
}