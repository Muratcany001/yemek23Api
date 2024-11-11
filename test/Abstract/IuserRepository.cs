using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Entities.appEntities;

namespace test.Abstract
{
    internal interface IuserRepository
    {
        User CreateUser(User user);
    }
}
