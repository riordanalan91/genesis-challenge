using Genesis.Challenge.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genesis.Challenge.Data.Queries
{
    public interface IUserQueries
    {
        UserDto Get(Guid userId);
        UserDto Get(string email);
    }
}
