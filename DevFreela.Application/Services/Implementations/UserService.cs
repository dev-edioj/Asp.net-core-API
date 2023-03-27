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
    public class UserService : IUserServices
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new UserComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
            _dbContext.UserComments.Add(comment);
            _dbContext.SaveChanges();

        }

        public void Delete(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            user.Active = false;
            _dbContext.SaveChanges();
        }

 
        public List<UserViewModel> GetAll()
        {
            var user = _dbContext.Users;

            var userViewModel = user 
                .Select( u => new UserViewModel(
                    u.FullName,
                    u.Email,
                    u.BirthDate,
                    u.createdAt,
                    u.Active
                    ))
                .ToList();
            return userViewModel;
        }


        public void Update(UpdateUserInputModel inputModel)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == inputModel.Id);

            user.Update( inputModel.FullName, inputModel.Email, inputModel.BirthDate);
            _dbContext.SaveChanges();
        }
    }
}
