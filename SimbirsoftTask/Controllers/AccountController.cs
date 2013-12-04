using System;
using System.Web;
using System.Web.Mvc;
using SimbirsoftTask.Models;
using SimbirsoftTask.Models.Repository;
using System.Web.Security;
using SimbirsoftTask.Providers;

namespace SimbirsoftTask.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private SqlRepository repo = new SqlRepository();

        /*public JsonResult CheckUserEmail(string Email)
        {
            User user = repo.GetUserByEmail(Email);
            var result = (user == null);
            return Json(result, JsonRequestBehavior.AllowGet);
        }*/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserEmail, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserEmail, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль или логин");
                }
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
        
        public ActionResult Register()
        {
            //ViewBag.RoleFieldVisible = false;
            //return View("~/Views/User/Create.cshtml");
            return View();
        }


        [HttpPost]
        public ActionResult Register([Bind(Include = "Id,Email,Password,Name,Surname,Birthday")] User user)
        {
            if (ModelState.IsValid)
            {
                using (SqlRepository repo = new SqlRepository())
                {
                    user.Role = repo.GetRoleByName("client");
                    user.RoleId = user.Role.Id;
                    bool result = repo.CreateUser(user);
                    if (result)
                    {
                        FormsAuthentication.SetAuthCookie(user.Email, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ошибка при регистрации");
                    }
                }
            }
            return View(user);
        }

        /*public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                MembershipUser membershipUser = ((CustomMembershipProvider)Membership.Provider).CreateUser(model.Email, model.Password);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Ошибка при регистрации");
                }
            }
            return View(model);
        }*/
    }
}