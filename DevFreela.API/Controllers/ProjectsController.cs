using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DevFreela.Controllers
{
    
    
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        //private readonly OpeningTimeOption _option;

        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

       
        [HttpGet]
        public IActionResult GetAll(string query)
        {
            
            var projects = _projectService.GetAll(query);
            return Ok(projects);
        }

       
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            //Buscar ou filtrar
            
            var projects = _projectService.GetById(id);
            if (projects == null)
            {
                return NotFound();
            }
            return Ok(projects);
        }

        [HttpPost]

        public IActionResult Post([FromBody] NewProjectInputModel inputModel)
        {
            //Cadastrar projeto
            if (inputModel.Title.Length > 200)
            {
                return BadRequest();
            }

           var id = _projectService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id }, inputModel);

        }

        [HttpPut("{id}")]
        public IActionResult Put( [FromBody] UpdateProjectInputModel inputModel)
        {
            // Editar ou atualizar projeto
            if (inputModel.Description.Length > 50)
            {
                return BadRequest();
            }

            _projectService.Update(inputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
            // Excluir projeto
            return NoContent();
        }
    }
}
