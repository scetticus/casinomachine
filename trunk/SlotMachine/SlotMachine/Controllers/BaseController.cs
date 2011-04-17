using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SlotMachine.Models;

namespace SlotMachine.Controllers
{
    public class BaseController : Controller
    {
        protected long UserId
        {
            get
            {
                return long.Parse(this.User.Identity.Name);
            }
        }

        protected SlotMachineEntities Ctx
        {
            get
            {
                if (ctx == null)
                {
                    this.ctx = new SlotMachineEntities();
                }
                return this.ctx;
            }
        }
        private SlotMachineEntities ctx;

        protected string GetStaticString(string str)
        {
            return str;
        }
    }
}
