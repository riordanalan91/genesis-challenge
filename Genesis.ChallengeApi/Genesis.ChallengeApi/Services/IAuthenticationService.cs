using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genesis.Challenge.Api.Services
{
    public interface IAuthenticationService
    {
        string GenerateJwt(Guid userId);
    }
}
