using LogInApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace LogInApp.Services
{
    public class SecurityService
    {


        UsersDAO usersDAO = new UsersDAO();
        public SecurityService()
        {

        }

        public bool IsValid(UserModel user)
        {
            // return true if user is found in a list
            return usersDAO.FindUser(user);

        }

    }
}
