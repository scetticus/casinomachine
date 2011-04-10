using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlotMachine.Models
{
    public partial class AppUser
    {        
        public string AccessToken { get; set; }
        public DateTime Expires { get; set; }
        public string Name { get; set; }
    }
}