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
                CreatedOnUtc = DateTime.Now,
                LastUpdatedOnUtc = DateTime.Now,
                LastLoginOnUtc = null
            });
            _usersDb.SaveChanges();

            return _usersDb.Users
                .Where(u => u.Id.Equals(userId))
                .FirstOrDefault();
        }
    }
}
