using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlotMachine.Models
{
    public class InMemoryUserStore
    {

        private static System.Collections.Concurrent.ConcurrentBag<AppUser> users = new System.Collections.Concurrent.ConcurrentBag<AppUser>();

        public static void Add(AppUser user)
        {
            if (users.SingleOrDefault(u => u.FacebookId == user.FacebookId) != null)
            {
                throw new InvalidOperationException("User already exists.");
            }

            users.Add(user);
        }

        public static AppUser Get(long facebookId)
        {
            return users.SingleOrDefault(u => u.FacebookId == facebookId);
        }

    }
}