using Genesis.Challenge.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genesis.Challenge.Data.Commands
{
    public interface IUserCommands
    {
        UserDto Create(string name, string email, string password, string telephoneNumbers);

        UserDto Update(
            string id,
            string token = null,
            string lastUpdatedOnUtc = null,
            string lastLoginOnUtc = null);
    }
}
