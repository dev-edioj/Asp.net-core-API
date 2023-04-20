using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userService;
        private readonly IMediator _mediator;
        public UsersController(IUserServices userService, IMediator mediator)
        {
            _userService = userService;
            _mediator= mediator;
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

        public  IActionResult PostComment([FromBody] CreateCommentCommand command)
        {
            //_userService.CreateComment(inputModel);

            var createComment = _mediator.Send(command);
            return Ok(createComment);
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
