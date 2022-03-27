using DemoWebApi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users);
    }

}
