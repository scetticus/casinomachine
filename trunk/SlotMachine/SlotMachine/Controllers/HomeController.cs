using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SlotMachine.Models;
using Facebook;
using Facebook.Web;
using Facebook.Web.Mvc;
using System.Web.Routing;

namespace SlotMachine.Controllers
{
    public class HomeController : Controller
    {
        public IFormsAuthenticationService FormsService { get; set; }        

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }            
            base.Initialize(requestContext);
        }

        [CanvasAuthorize(Permissions = "user_about_me")]
        public ActionResult Index()
        {            
            LogInUser();            
            return View();
        }

        public ActionResult Play()
        {
            return View();
        }

        private void LogInUser()
        {
            if (!User.Identity.IsAuthenticated)
            {
                var fb = new FacebookWebClient();
                dynamic result = fb.Get("me");
                FormsService.SignIn(result.id, true);
            }
        }        
    }
}
