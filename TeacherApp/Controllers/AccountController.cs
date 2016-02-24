using EduTestServiceClient.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TeacherApp.Security;
using TeacherApp.ViewModels;

namespace TeacherApp.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationService _accountService;

        public AccountController(IAuthenticationService accountService)
        {
            _accountService = accountService;
        }

        public ActionResult LogOn()
        {
            var viewModel = new LogOnViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOn(LogOnViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var resp = _accountService.Authenticate(model.Login.Trim(), model.Password.Trim());

                if (resp != null)
                {                    
                    FormsAuthentication.SetAuthCookie(model.Login, false);   
                    HttpContext.User = new CustomPrincipal(null, resp);

                    return RedirectToLocal(returnUrl);
                }
            }

            ModelState.AddModelError(string.Empty, "The user name or password provided is incorrect.");
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Manage()
        {
            return View();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}