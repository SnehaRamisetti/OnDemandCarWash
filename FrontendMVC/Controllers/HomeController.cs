using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FrontendMVC.Models;
using FrontendMVC.Repository;
using Newtonsoft.Json;

namespace FrontendMVC.Controllers
{
    public class HomeController : Controller
    {
        //Home page
        public ActionResult Display()
        {
            return View("Display");
        }

        //To Implement Registration
        #region
        public async Task<ActionResult> RegisterUser(UserViewModel userView)
        {
            if (ModelState.IsValid)
            {
                UserViewModel user = new UserViewModel();
                var service = new servicerepo();
                {
                    using (var response = service.PostResponse("user", userView))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        user = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);

                    }
                }
                return RedirectToAction("PackageDetails", "Package");
            }
            return View(userView);
        }
        #endregion

        //To Implement Login
        #region
        public ActionResult LoginUser()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> LoginUser(LoginviewModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserViewModel newUser = new UserViewModel();
                    var service = new servicerepo();
                    {
                        using (var response = service.VerifyLogin("UserAccount/VerifyLogin", login))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                        }
                    }
                    if (newUser != null)
                    {
                        ViewBag.message = "Login Success";
                    }
                    else
                    {
                        ViewBag.message = "incorrect";
                    }
                }
            }
            catch
            {
                throw;
            }
            return RedirectToAction("PackageDetails", "Package");

        }
        #endregion


        //It will validate the Email & Password valid or not using WebAPI
        #region
        public ActionResult LoginUserZ()
        {
            return View();
        }

        public async Task<ActionResult> LoginUserZ(UserViewModel Ur)
        {
            if (!(string.IsNullOrEmpty(Ur.Email) || string.IsNullOrEmpty(Ur.Password)))
            {

                if (!ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44343/api/UserAccount/custLogin");

                           var checkLogin = client.PostAsJsonAsync<UserViewModel>("User", Ur);//Asynchronosly passing the values in Json Format to API
                            var checkrec = checkLogin.Result;//Checking the User Login ID & Password 

                            //Condition for Successfull Login We need to Navigate to Flght Seach Page 
                            if ((int)checkrec.StatusCode == 200)
                            {
                                ViewBag.message = "Login Success!!";
                            }
                            //Condition for Invalid User Name & Password
                            if ((int)checkrec.StatusCode == 426)
                            {
                                ViewBag.message = "Invalid User Id & Password";
                            }

                    return RedirectToAction("PackageDetails", "Package");
                }
                
            }
            return View("Display");

        }
        #endregion
    }

}
