﻿using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserServices
    {
        List<UserViewModel> GetAll();

        int Create(NewUserInputModel inputModel);
        void CreateComment(CreateCommentInputModel inputModel);

        void Update(UpdateUserInputModel inputModel);

        void Delete(int id);
    }
}
