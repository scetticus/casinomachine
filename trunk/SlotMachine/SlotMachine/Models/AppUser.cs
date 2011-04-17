using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace SlotMachine.Models
{
    public partial class AppUser
    {
        public string AccessToken { get; set; }
        public DateTime Expires { get; set; }
        public string Name { get; set; }

        public static AppUser CreateAppUser(long fbId)
        {
            AppUser appUser = new AppUser();
            appUser.FacebookId = fbId;
            appUser.Points = double.Parse(System.Configuration.ConfigurationManager.AppSettings["InitialCredit"]);
            appUser.LastVisited = DateTime.Now;
            
            //appUser.TimesPlayed = 0;
            //appUser.JackPotCount = 0;
            //appUser.TotalInvitationSent = 0;
            //appUser.InvitationSentToday = 0;

            return appUser;
        }
    }
}