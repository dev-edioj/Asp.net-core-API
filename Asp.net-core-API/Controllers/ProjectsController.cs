using Asp.net_core_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_core_API.Controllers
{
    //Definindo uma rota base
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        // api/projects?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            //Buscar ou filtrar todos
            return Ok();
        }

        // /api/projects/1
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            //Buscar ou filtrar
            //return NotFound();
            return Ok();
        }

        [HttpPost]
        
        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {
            //Cadastrar projeto
           if (createProject.Title.Length > 50)
           {
            return BadRequest();
           } 

           return CreatedAtAction(nameof(GetById), new {id = createProject.Id}, createProject);
            
        }

    [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
        {
            // Editar ou atualizar projeto
            if (updateProject.Description.Length > 50)
            {
                return BadRequest();
            }   

            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            // Excluir projeto
            return NoContent();
        }
    }
}
