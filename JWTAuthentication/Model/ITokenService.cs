using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Model
{
    public interface ITokenService
    {
        string GenerateJsonWebToken(User userInfo);
    }
}
