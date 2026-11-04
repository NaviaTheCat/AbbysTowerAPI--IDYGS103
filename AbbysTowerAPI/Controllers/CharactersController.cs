//using Domain.DTO;
using Domain.Entities;
using AbbysTowerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace AbbysTowerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterServices _characterServices;
        public CharactersController(ICharacterServices characterServices)
        {
            _characterServices = characterServices;
        }
        //GET
        [HttpGet]
        public async Task<IActionResult> GetCharacters()
        {
            var response = await _characterServices.GetAllCharacters();
            return Ok(response);
        }

        //GET by ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> CharacterById(int id)
        {
            var response = await _characterServices.CharacterById(id);
            return Ok(response);
        }
        //POST 
        [HttpPost]
        public async Task<IActionResult> CreateCharacter(Characters request)
        {
            var response = await _characterServices.CreateCharacter(request);
            return Ok(response);
        }
        //UPDATE
        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(int id,Characters request)
        {
            var response = await _characterServices.UpdateCharacter(id, request);
            return Ok(response);
        }
        //DELETE
        [HttpDelete]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var response = await _characterServices.DeleteCharacter(id);
            return Ok(response);
        }
    }

}
