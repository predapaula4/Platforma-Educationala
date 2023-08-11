using Online_Platform.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Platform.Models.BusinessLogic
{
    class UserBusinessLogic
    {
        public User user;
        public UserDA userDa;

        public UserBusinessLogic()
        {
            user = new User();
            userDa = new UserDA();
        }

        public User GetUser()
        {
            return userDa.GetUser(user);
        }
        

    }
}
