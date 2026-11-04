using AbbysTowerAPI.Services.Interfaces;
using AbbysTowerAPI.Services.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AbbysTowerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LevelsController: ControllerBase
    {
        private readonly ILevelServices _levelServices;

        public LevelsController(ILevelServices levelServices)
        {
            _levelServices = levelServices;
        }
        //GET
        [HttpGet]
        public async Task<IActionResult> GetLevels()
        {
            var response = await _levelServices.GetAllLevels();
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> LevelById(int id)
        {
            var response = await _levelServices.GetLevelById(id);
            return Ok(response);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> CreateLevel(Levels request)
        {
            var response = await _levelServices.CreateLevel(request);
            return Ok(response);
        }


        // PUT
        [HttpPut]
        public async Task<IActionResult> UpdateLevel(int id, Levels request)
        {
            var response = await _levelServices.UpdateLevel(id, request);
            return Ok(response);
        }

        // DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteLevel(int id)
        {
            var response = await _levelServices.DeleteLevel(id);
            return Ok(response);
        }
    }
}
