using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Genesis.Challenge.Api.Models;
using Genesis.Challenge.Data.Commands;
using Genesis.Challenge.Data.Queries;
using Newtonsoft.Json;

namespace Genesis.Challenge.Api.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserQueries _userQueries;
        private readonly IUserCommands _userCommands;

        public UsersService(IUserQueries userQueries, IUserCommands userCommands)
        {
            _userQueries = userQueries;
            _userCommands = userCommands;
        }

        public UserModel Create(UserCreationModel model)
        {
            var result = _userCommands.Create(
                model.Name, 
                model.Email, 
                model.Password, 
                JsonConvert.SerializeObject(model.TelephoneNumbers));

            if (result == null)
            {
                return null;
            }

            return new UserModel()
            {
                Id = result.Id,
                CreatedOn = result.CreatedOnUtc,
                LastUpdatedOn = result.LastUpdatedOnUtc,
                LastLoginOn = result?.LastLoginOnUtc
            };
        }

        public UserModel Get(string userId)
        {
            Guid userGuid = Guid.Empty;
            Guid.TryParse(userId, out userGuid);

            var result = _userQueries.Get(userGuid);

            return new UserModel()
            {
                Id = result.Id,
                CreatedOn = result.CreatedOnUtc,
                LastLoginOn = result.LastUpdatedOnUtc,
                LastUpdatedOn = result.LastUpdatedOnUtc
            };
        }

        public UserModel AuthenticateUser(string email, string password)
        {
            var result = _userQueries.Get(email);

            if ((result != null) && (result.Password.Equals(password)))
            {
                return new UserModel()
                {
                    Id = result.Id,
                    CreatedOn = result.CreatedOnUtc,
                    LastLoginOn = result.LastUpdatedOnUtc,
                    LastUpdatedOn = result.LastUpdatedOnUtc
                };
            }
            else
            {
                return null;
            }
        }
    }
}
