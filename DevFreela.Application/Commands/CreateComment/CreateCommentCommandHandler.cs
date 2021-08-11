using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public CreateCommentCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var newComment = new ProjectComment(request.Content, request.IdUser, request.IdProject);

            await _dbContext.ProjectComments.AddAsync(newComment);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
