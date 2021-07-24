using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewUserInputModel inputModel)
        {
            var newUser = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

            _dbContext.Users.Add(newUser);

            return newUser.Id;
        }

        public UserViewModel GetUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

            if(user == null)
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
