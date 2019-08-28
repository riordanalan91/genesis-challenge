using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Genesis.Challenge.Api.Models;
using Genesis.Challenge.Data.Commands;
using Genesis.Challenge.Data.Queries;
using Microsoft.IdentityModel.Tokens;
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
                CreatedOnUtc = result.CreatedOnUtc,
                LastUpdatedOnUtc = result.LastUpdatedOnUtc,
                LastLoginOnUtc = result?.LastLoginOnUtc
            };
        }

        public UserModel Get(string userId)
        {
            Guid userGuid = Guid.Empty;
            Guid.TryParse(userId, out userGuid);

            var result = _userQueries.Get(userGuid);

            if (result == null) {
                return null;
            }

            return new UserModel()
            {
                Id = result.Id,
                CreatedOnUtc = result.CreatedOnUtc,
                LastLoginOnUtc = result.LastUpdatedOnUtc,
                LastUpdatedOnUtc = result.LastUpdatedOnUtc,
                Token = result.Token
            };
        }

        public UserModel AuthenticateUser(string email, string password)
        {
            var result = _userQueries.Get(email);

            if ((result != null) && (result.Password.Equals(password)))
            {
                var user = new UserModel()
                {
                    Id = result.Id,
                    CreatedOnUtc = result.CreatedOnUtc,
                    LastLoginOnUtc = result.LastLoginOnUtc,
                    LastUpdatedOnUtc = result.LastUpdatedOnUtc
                };
                return user;
            }
            else return null;
        }

        public UserModel Update(
            string id,
            string token = null,
            string lastUpdatedOnUtc = null,
            string lastLoginOnUtc = null)
        {
            var result = _userCommands.Update(id, token, lastUpdatedOnUtc, lastLoginOnUtc);
            if (result == null)
            {
                return null;
            }

            return new UserModel()
            {
                Id = result.Id,
                CreatedOnUtc = result.CreatedOnUtc,
                LastLoginOnUtc = result.LastLoginOnUtc,
                LastUpdatedOnUtc = result.LastUpdatedOnUtc,
                Token = result.Token
            };
        }
    }
}
