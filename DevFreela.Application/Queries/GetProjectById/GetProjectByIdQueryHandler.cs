using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Project>
    {
        private readonly IProjectRepository _projectRepository;
        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Project> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            return await _projectRepository.GetByIdAsync(request.Id);
        }
    }
}
