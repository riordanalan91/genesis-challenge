using Genesis.Challenge.Data.Contexts;
using Genesis.Challenge.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genesis.Challenge.Data.Commands
{
    public class UserCommands : IUserCommands
    {
        private readonly UsersDbContext _usersDb;

        public UserCommands(UsersDbContext userDbContext)
        {
            _usersDb = userDbContext;
        }

        public UserDto Create(string name, string email, string password, string telephoneNumbers)
        {
            var user = _usersDb.Users
                .Where(u => u.Email.Equals(email))
                .FirstOrDefault();

            if (user != null)
            {
                return null;  
            }

            var userId = Guid.NewGuid();
            _usersDb.Add(new UserDto
            {
                Id = userId,
                Email = email,
                Password = password,
                TelephoneNumbers = telephoneNumbers,
                CreatedOnUtc = DateTime.UtcNow,
                LastUpdatedOnUtc = DateTime.UtcNow,
                LastLoginOnUtc = null
            });
            _usersDb.SaveChanges();

            return _usersDb.Users
                .Where(u => u.Id.Equals(userId))
                .FirstOrDefault();
        }

        public UserDto Update(
            string id, 
            string token = null,
            string lastUpdatedOnUtc = null,
            string lastLoginOnUtc = null)
        {
            Guid userGuid = Guid.Empty;
            Guid.TryParse(id, out userGuid);

            var user = _usersDb.Users.Where(u => u.Id.Equals(userGuid)).FirstOrDefault();

            if (user != null)
            {
                if (token != null) user.Token = token;
                if (lastUpdatedOnUtc != null)
                {
                    DateTime lastUpdatedOn;
                    var isValid = DateTime.TryParse(lastUpdatedOnUtc, out lastUpdatedOn);

                    if (isValid) user.LastUpdatedOnUtc = lastUpdatedOn;
                    else return null;
                }
                if (lastLoginOnUtc != null)
                {
                    DateTime lastLoginOn;
                    var isValid = DateTime.TryParse(lastLoginOnUtc, out lastLoginOn);

                    if (isValid) user.LastLoginOnUtc = lastLoginOn;
                    else return null;
                }

                _usersDb.Users.Update(user);
                _usersDb.SaveChanges();

                return user;
            }
            else return null;
        }
    }
}
