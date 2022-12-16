using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FrontendMVC.Models;
using FrontendMVC.Repository;
using Newtonsoft.Json;

namespace FrontendMVC.Controllers
{
    public class PackageController : Controller
    {
        // To display all the avaliable packages
        #region
        public async Task<ActionResult> PackageDetails()
        {
            List<PackageViewModel> packages = new List<PackageViewModel>();
            var service = new servicerepo();
            {
                using (var response = service.GetResponse("Package"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                   packages = JsonConvert.DeserializeObject<List<PackageViewModel>>(apiResponse);
                }
            }
            return View(packages);
        }
        #endregion
    }
}