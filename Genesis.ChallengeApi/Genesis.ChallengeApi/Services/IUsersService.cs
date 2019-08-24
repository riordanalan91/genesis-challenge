using Genesis.Challenge.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genesis.Challenge.Api.Services
{
    public interface IUsersService
    {
        UserModel Get(string userId);

        UserModel Create(UserCreationModel model);

        UserModel AuthenticateUser(string email, string password);
    }
}
