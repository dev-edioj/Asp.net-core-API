using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userService;
        public UsersController(IUserServices userService)
        {
            _userService = userService;

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewUserInputModel inputModel)
        {
            var id = _userService.Create(inputModel);

            return CreatedAtAction(nameof(Get), new {id = id}, inputModel );
        }

        [HttpPost("{id}/comment")]

        public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel inputModel)
        {
            _userService.CreateComment(inputModel);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserInputModel inputModel)
        {
            _userService.Update(inputModel);
            return NoContent();
        }


        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
         
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return NoContent();
        }
    }
}
