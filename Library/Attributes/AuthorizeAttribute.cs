using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
 using System.Security.Principal;
 using System.Web.Mvc.Properties;

namespace Library.Attributes
{

    // Custom attribute for role management with activities.

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizeActivity : AuthorizeAttribute
    {
        private string Activity;

        AuthorizeActivity(string Activity)
        {
            this.Activity = Activity;
        }


        
    }

}





