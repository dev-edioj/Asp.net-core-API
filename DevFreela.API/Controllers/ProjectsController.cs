using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.net_core_API.Controllers
{
    //Definindo uma rota base
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _option;

        public ProjectsController(IOptions<OpeningTimeOption> option, ExampleClass exampleClass)
        {
            exampleClass.Name = "Update at ProjectsController";

            _option = option.Value;
        }
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
            if (createProject.Title.Length > 200)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);

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
