using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Repository
{
    internal interface IAccount
    {

       UserTable VerifyLogin(string email, string password);


    }
}
