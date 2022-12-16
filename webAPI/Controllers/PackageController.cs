using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI.Models;
using webAPI.Repository;

namespace webAPI.Controllers
{
    [RoutePrefix("api/package")]
    public class PackageController : ApiController
    {

        IUser<Package> _package;
        public PackageController()
        {
            this._package = new PackageRepo (new GreenWashEntities1());
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Package> GetAll()
        {
            var packages = _package.Get();
            return packages;
        }


    }
}
