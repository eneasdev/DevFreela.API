using DevFreela.API.Models;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        //api/projects?query=string
        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _projectService.GetAll(query);

            return Ok(projects);
        }

        //api/projects/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

            if(project == null)
            {
                NotFound();
            }
            
            return Ok(project);
        }

        //api/projects
        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel inputModel)
        {
            if(inputModel.Title.Length > 50)
            {
                return BadRequest();
            }

            var id = _projectService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        //api/projects/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputModel)
        {
            if(inputModel.Description.Length > 200)
            {
                return BadRequest();
            }

            _projectService.Update(inputModel);

            return NoContent();
        }

        //api/projects/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);

            return NoContent();
        }

        //api/projects/1/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment ([FromBody] NewCommentInputModel inputModel)
        {
            _projectService.CreateComment(inputModel);

            return NoContent();
        }

        //api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);

            return NoContent();
        }

        //api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);

            return NoContent();
        }
    }
}
