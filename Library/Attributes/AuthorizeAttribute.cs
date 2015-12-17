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


        //public void AuthActivityAttribute(string Activity)
        //{
        //    User currentUser = GetCurrentUser();

        //    if (GetUserActivities(currentUser).Contains(Activity))
        //    {
        //        // Authorized
        //    }
        //    else
        //    {
        //        // Unauthorized
        //    }
        //}

        //public List<Activity> GetUserActivities(User currentUser)
        //{
        //    List<Role> roles = GetUserRoles(currentUser);
        //    List<Activity> activities = new List<Activity>();

        //    foreach (Role role in roles)
        //    {
        //        List<Activity> roleActivities = GetRoleActivities(role);
        //        activities.AddRange(roleActivities);
        //    }

        //    return activities;

        // If we wanted to be concise, this whole method could be written as:
        // return GetUserRoles( currentUser ).SelectMany( x => x.GetRoleActivities( x ) );
        //}
       

        
    }

}





