using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly DevFreelaDbContext _dbContext;
        public GetUserQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id);

            if (user == null)
            {
                return null;
            }

            var userViewModel = new UserViewModel(
                user.FullName,
                user.Email,
                user.BirthDate,
                user.CreatedAt
                );

            return userViewModel;
        }
    }
}
