using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SlotMachine.Models;
using Facebook.Web.Mvc;

namespace SlotMachine.Controllers
{
    public class GameController : BaseController
    {
        [CanvasAuthorize(Permissions = "user_about_me")]
        public ActionResult Play()
        {
            return View();
        }

        public ActionResult GetScore()
        {
            AppUser user = Ctx.AppUsers.FirstOrDefault(u => u.Id == this.UserId);
            return this.Json(user.Points, JsonRequestBehavior.AllowGet);
        }
    }
}
