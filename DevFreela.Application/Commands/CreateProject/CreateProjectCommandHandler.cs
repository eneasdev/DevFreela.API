using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly DevFreelaDbContext _projectRepository;
        public CreateProjectCommandHandler(DevFreelaDbContext projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var newProject = new Project(request.Title, request.Descripction, request.IdClient, request.IdFreeLancer, request.TotalCost);

            await _projectRepository.AddAsync(newProject);

            return newProject.Id;
        }
    }
}
