using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.Services.Interfaces;
using MediatR;
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
        private readonly IMediator _mediator;
        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }

       
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {

            var getAllProjectsQuery = new GetAllProjectsQuery(query);

            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

       
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {

            //Buscar ou filtrar
            var query = new GetProjectByIdQuery(id);

            var projects = await _mediator.Send(query);
            if (projects == null)
            {
                return NotFound();
            }
            return Ok(projects);
        }

        [HttpPost]

        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            //Cadastrar projeto
            if (command.Title.Length > 200)
            {
                return BadRequest();
            }

            //var id = _projectService.Create(inputModel);

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put( [FromBody] UpdateProjectCommand command)
        {
            // Editar ou atualizar projeto
            if (command.Description.Length > 50)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] FinishProjectCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(DeleteProjectCommand command)
        {
           await _mediator.Send(command);
         
            return NoContent();
        }
    }
}
