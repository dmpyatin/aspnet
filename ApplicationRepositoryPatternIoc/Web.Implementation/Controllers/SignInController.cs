using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Implementation.Models;
using Web.Implementation.Infrastructure;
using EfRepPatTest.Service;


namespace Web.Implementation.Controllers{


    public class SignInController : Controller
    {

        ISessionWrapperRepository SessionWrapper;
        IFormsAuthenticationWrapper AuthenticationWrapper;
        IDataService DataService;
        TranslationController Translation; 

        public SignInController(IDataService dataService, ISessionWrapperRepository sessionWrapper, IFormsAuthenticationWrapper authenticationWrapper)
        {
            this.SessionWrapper = sessionWrapper;
            this.AuthenticationWrapper = authenticationWrapper;
            this.DataService = dataService;
            Translation = new TranslationController(this.DataService);
        }

        /*public SignInController(IFormsAuthenticationWrapper authenticationWrapper)
        {
            
        }*/


        //
        // GET: /SignIn/
        public ActionResult Index()
        {
            //HttpContextBase

            return Translation.TranslateView(View(), ControllerContext, 1);
        }

        [HttpPost]
        public ActionResult Index(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {

                    if (model.UserName == "admin" && model.Password == "admin")
                    {
                        AuthenticationWrapper.SetCookie(model.UserName, model.RememberMe);

                        if (SessionWrapper.GetSession(User.Identity.Name) == null)
                        {
                            SessionWrapper.SetSession(User.Identity.Name, "signin");
                        }

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        //ModelState.AddModelError("", "Имя пользователя или пароль некорректны");
                    }
                }
                
            }
            return RedirectToAction("Index", "SignIn");
        }

        //
        // GET: /Account/SignOut

        public ActionResult SignOut()
        {
            AuthenticationWrapper.SignOut();

            //Session[User.Identity.Name] = null;

            SessionWrapper.SetSession(User.Identity.Name, null);
            
            return RedirectToAction("Index", "Home");
        }

    }
}
