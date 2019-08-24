using Genesis.Challenge.Data.Contexts;
using Genesis.Challenge.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genesis.Challenge.Data.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly UsersDbContext _usersDb;

        public UserQueries(UsersDbContext usersDbContext)
        {
            _usersDb = usersDbContext;
        }

        public UserDto Get(Guid userId)
        {
            return _usersDb.Users
                .Where(user => user.Id.Equals(userId))
                .FirstOrDefault();
        }

        public UserDto Get(string email)
        {
            return _usersDb.Users
                .Where(user => user.Email.Equals(email))
                .FirstOrDefault();
        }
    }
}
