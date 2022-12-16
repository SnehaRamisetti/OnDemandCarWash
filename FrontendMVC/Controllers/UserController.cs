using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FrontendMVC.Models;
using FrontendMVC.Repository;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json;

namespace FrontendMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        #region
        public async Task<ActionResult> Index()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            var service = new  servicerepo();
            {
                using (var response = service.GetResponse("User"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<UserViewModel>>(apiResponse);
                }
            }
            return View(users);
        }
        #endregion
        //adding users through MVC
        #region
        public async Task<ActionResult> AddUser(UserViewModel userView)
        {
            if(ModelState.IsValid)
            {
                UserViewModel user = new UserViewModel();
                var service=new servicerepo();
                {
                    using(var response = service.PostResponse("user",  userView))
                    {
                        string apiResponse=await response.Content.ReadAsStringAsync();
                        user=JsonConvert.DeserializeObject<UserViewModel>(apiResponse);

                    }
                }
                return RedirectToAction("Index");
            }
            return View(userView);
        }
        #endregion
        //Deleting the user details through MVC
        #region
        public async Task<ActionResult> DeleteUser(int id)
        {

            var service = new servicerepo();
            {
                using (var response = service.DeleteResponse("user/", id))
                {
                    string apiResponse=await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");

        }
        #endregion
        //Updating the user details
        #region       
        public async Task<ActionResult> EditUser(int id)
        {
           
                UserViewModel user = new UserViewModel();
                var service = new servicerepo();
                {
                    using (var response = service.UpdateResponse("user/",id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        user= JsonConvert.DeserializeObject<UserViewModel>(apiResponse);

                    }
                }
                return View(user);

        }
        [HttpPost]
        public async Task<ActionResult> EditUser(UserViewModel userView)
        {
            if (ModelState.IsValid)
            {
                UserViewModel user = new UserViewModel();
                var service = new servicerepo();
                {
                    using (var response = service.EditResponse("user", userView))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        user = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);

                    }
                }
                return RedirectToAction("Index");
            }
            return View(userView);
           
        }
        #endregion

    }
}