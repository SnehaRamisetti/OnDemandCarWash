using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webAPI.Models;

namespace webAPI.Repository
{
    public class AccountRepo :IAccount
    {

        GreenWashEntities1 _entities = null;


        public AccountRepo(GreenWashEntities1 DBEntities)
        {
            this._entities = DBEntities;
        }

        public UserTable VerifyLogin(string email, string password)
        {
             UserTable user = null;
            try
            {
                var checkValidUser = _entities. UserTables.Where(m => m.Email == email &&
            m.Password == password).FirstOrDefault();
                if (checkValidUser != null)
                {
                    user = checkValidUser;
                }

                else
                {
                    user = null;
                }
            }
            catch (Exception ex)
            {
            }
            return user;
        }



    }
}