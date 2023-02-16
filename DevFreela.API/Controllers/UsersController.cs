using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_core_API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
       
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel createadUserModel)
        {
            return NoContent();
        }

        [HttpPost("{id}/comment")]

        public IActionResult PostComment(int id, [FromBody] CreateCommentModel createComment)
        {
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserModel updateUser)
        {
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
            return NoContent();
        }
    }
}
