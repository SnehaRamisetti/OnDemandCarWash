using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using webAPI.Models;
using webAPI.Repository;


namespace webAPI.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        Repository.IUser<UserTable> _user;
        public UserController()
        {
            this._user = new UserRepo(new GreenWashEntities1());
        }
        //Getting all the user details
        #region
        [HttpGet]
        [Route("")]
        public IEnumerable<UserTable> Get()
        {
            var users = _user.Get();
            return users;
        }
        #endregion
        //Adding new user
        #region
        [HttpPost]
        [Route("")]

        public IHttpActionResult AddUser(UserTable user)
        {
            UserTable userobj = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("InValid data.");
                _user.AddUser(user);

            }
            catch (Exception)
            {

                throw;
            }
            return Ok("Data Saved");
        }
        #endregion
        //Deleting the existing data
        #region

        [HttpDelete]
       
        public IHttpActionResult DeleteUser(int Id)
        {
            try
            {
                if (Id <= 0)
                    return BadRequest("Not a valid student id");

                _user.DeleteUser(Id);
            }
            catch
            {
                throw;
            }

            return Ok("Deleted Successfully!");
        }
        #endregion

        [HttpGet]
        public UserTable GetById(int Id)
        {
             var USER = _user.GetById(Id);
             return USER;
        }
        //Updating the existing data
        #region
        [HttpPut]
        public IHttpActionResult UpdateUser(int id, UserTable user)
        {
            try
            {


                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");

                _user.UpdateUser(id, user);
            }
            catch
            {
                throw;
            }

            return Ok("Updated Successfully");
        }
        #endregion

    }

}
