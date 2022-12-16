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
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        //IAdmin<Admin> _admin;
        //public AdminController()
        //{
        //    this._admin = new AdminRepo(new GreenWashEntities1());
        //}
        //[HttpGet]
        //[Route("")]
        //public IEnumerable<Admin> Get()
        //{
        //    var users = _admin.Get();
        //    return users;
        //}
    }
}
