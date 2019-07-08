using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace JWTAuthentication.Model
{
    public class UserService : IUserService
    {
        public User Authenticate(User login)
        {
            User user = null;

            //Validate the User from database
            if (login.Username == "jacob")
            {
                user = new User { Username = "jacob oram", EmailAddress = "joram@gmail.com", Designation = "manager" };
            }
            return user;
        }

       

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
