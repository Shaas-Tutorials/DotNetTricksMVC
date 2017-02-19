using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Site.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public CustomPrincipal(string userName)
        {
            this.Identity = new GenericIdentity(userName);
        }
        //authentication
        public IIdentity Identity
        {
            private set;
            get;
        }

        //authorization
        public bool IsInRole(string role)
        {
            if (!Roles.Any(r => role.Contains(r)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string[] Roles { get; set; }
    }
}