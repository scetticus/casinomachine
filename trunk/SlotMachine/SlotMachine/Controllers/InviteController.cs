using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SlotMachine.Models;
using Facebook.Web;

namespace SlotMachine.Controllers
{
    public class InviteController : BaseController
    {
        public ActionResult Sent()
        {
            if (Request.Form["ids[]"] != null)
            {
                string ids = Request.Form["ids[]"].ToString();
                int friendsInvitedCount = ids.Split(new char[] { ',' }).Length;

                //IncreaseInvitationsCount(friendsInvitedCount);
            }
            
            return Facebook.Web.Mvc.CanvasControllerExtensions.CanvasRedirectToAction(this, "Play", "Game");            
        }

        private void IncreaseInvitationsCount(int friendsInvitedCount)
        {
            AppUser user = Ctx.AppUsers.FirstOrDefault(u => u.Id == this.UserId);
            user.InvitationSentToday += friendsInvitedCount;
            user.TotalInvitationSent += friendsInvitedCount;
            Ctx.SaveChanges();

        }

    }
}
