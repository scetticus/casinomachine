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
using System.Text;

namespace SlotMachine.Controllers
{
    public class HomeController : BaseController
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

        private void LogInUser()
        {
            if (!User.Identity.IsAuthenticated)
            {
                FacebookWebClient fb = new FacebookWebClient();
                dynamic result = fb.Get("me");
                long fbId = long.Parse(result.id);

                AppUser appUser = Ctx.AppUsers.FirstOrDefault(u => u.FacebookId == fbId);

                if (appUser == null)
                {
                    appUser = AppUser.CreateAppUser(fbId);
                    Ctx.AppUsers.AddObject(appUser);
                }
                else
                {
                    if (appUser.LastVisited != DateTime.Today)
                    {
                        appUser.LastVisited = DateTime.Today;
                        appUser.InvitationSentToday = 0;
                    }
                }

                Ctx.SaveChanges();

                FormsService.SignIn(appUser.Id.ToString(), false);
            }
        }
    }
}
