using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Model
{
    public interface IUserService
    {
        User Authenticate(User login);
        IEnumerable<User> GetAll();
    }
}
