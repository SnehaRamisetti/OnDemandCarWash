using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using webAPI.Models;
using webAPI.Repository;
using Login = webAPI.Models.Login;

namespace webAPI.Controllers
{
    [RoutePrefix("api/UserAccount")]
    public class UserAccountController : ApiController
    {

        private IAccount  _account ;
        public UserAccountController()
        {
            this._account  = new AccountRepo (new GreenWashEntities1());
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult VerifyLogin(Login objlogin)
        {
            UserTable user = null;
            try
            {
                 user = _account .VerifyLogin(objlogin.email, objlogin.password);

                if ( user != null)
                {
                    
                    return Ok(user);

                }

            }
            catch (Exception ex)
            {
                throw;

            }

             
            return NotFound();

        }


        public IHttpActionResult custLogin(UserRegisterModel Ur)
        {
             GreenWashEntities1 nd = new GreenWashEntities1();

            var checkValidUser = nd.UserTables.Where(m => m.Email == Ur.Email &&
            m.Password == Ur.Password).FirstOrDefault();

            if (checkValidUser != null)
            {
                return Ok();
            }

            else
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse((HttpStatusCode)426, new HttpError("Something goes wrong")));
            }
        }



    }
}
