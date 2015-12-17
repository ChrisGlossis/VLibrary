using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Library.Models;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;


namespace Library.Controllers
{
    public class AdminPanelController : Controller
    {
        ApplicationDbContext context =  new Library.Models.ApplicationDbContext();

       
        // GET: AdminPanel
        public ActionResult Index()
        {
            //// Olo auto pou einai sto index tha prepei na trexei stin arxi tou programmatos oxi edw. 
            //var MyRoleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(context));
            
            //foreach (string element in CustomRoles.Roles.RolesList)
            //{
            //    if (!MyRoleManager.RoleExists(element))
            //    {
                    
            //        context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //        {
            //            Name = element
            //        });
            //        context.SaveChanges();    
                
            //    }
            //}




            return View();
        }

        public async Task <PartialViewResult> ShowUsersAndRoles()
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var MyRoleManager = new RoleManager<IdentityRole>(roleStore);
            var MyUserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

         
            // Get the list of Users in this Role
            //var users = new List<ApplicationUser>();

            // Get the list of Users in this Role
            //foreach (var user in MyUserManager.Users.ToList())
            //{
                
            //        users.Add(user);
              
            //}

            //ViewBag.Users = users;
            //ViewBag.UserCount = users.Count();
            ApplicationListUsersAndRoles ListUsersAndRoles = new ApplicationListUsersAndRoles();
        
            foreach (var User in MyUserManager.Users.ToList())
            {
               
                ListUsersAndRoles.Add(new UserRolesViewModel ( User,  await MyUserManager.GetRolesAsync(User.Id)));
                
            }

            return PartialView("_ListUsersAndRolesPartial", ListUsersAndRoles);
        }

        public ActionResult ManageRoles()
        {
           return View();
        }

    
        public PartialViewResult  RolesList()
        {
            
            var Roles = context.Roles.ToList();
            return PartialView("_ShowRolesListPartial", Roles);
            //return View(Roles); 
        }

        public PartialViewResult  ManageUserRole()
        {
         

            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(lr => new SelectListItem { Value = lr.Name.ToString(), Text = lr.Name }).ToList();
            ViewBag.Roles = list;
            return PartialView("_ManageUserRoles");    
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> AddRoleToUser(string UserName, string RoleName)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var MyRoleManager = new RoleManager<IdentityRole>(roleStore);
            IList<string> UserRoleName = new List<string>();
            var MyUserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var User = MyUserManager.Users.Where(u => u.UserName == UserName).FirstOrDefault();

            //var User = context.Users.ToList().Where(x => x.UserName == UserName).FirstOrDefault();
             
             if (User != null)
             {
               
                 if (MyRoleManager.RoleExists(RoleName))
                 {
                     
                     if (await MyUserManager.IsInRoleAsync(User.Id,RoleName) == false)
                     {
                         try
                         {
                             //User.Roles.Add(new IdentityUserRole { RoleId = role.Id });
                             //context.SaveChangesAsync();
                             //ViewBag.AddRoleToUserResultMessage = "Role added successfully !";

                            
                             MyUserManager.AddToRole(User.Id, RoleName);
                             ViewBag.AddRoleToUserResultMessage = "The role added successfully.";                             
                             
                         }
                         catch(Exception)
                         {
                             //We can safe the error in a log file
                             ViewBag.AddRoleToUserResultMessage = "The system can not save the changes.";
                         }
                     }
                     else
                     {
                         ViewBag.AddRoleToUserResultMessage = "User: " + UserName + " already has this role:" + RoleName + ".";
                     }
                 }
                 else
                 {
                     ViewBag.AddRoleToUserResultMessage = "This role does not exists.";
                 }
             }
             else
             {
                 ViewBag.AddRoleToUserResultMessage = "There is not exist a user with Username: " + UserName;
             }



            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            return PartialView("_ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> GetUserRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                IList<string> UserRoleName = new List<string>();
                var MyUserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var User = MyUserManager.Users.Where(u => u.UserName == UserName).FirstOrDefault();
                //var AllUsers = context.Users.ToList();
               // var User = context.Users.ToList().Where(x => x.UserName == UserName).FirstOrDefault();

                if (User != null)
                {
                    //var UserRolesID = User.Roles.Select(r => r.RoleId);

                    //var UserRoles = context.Roles.ToList();
                   
                    //foreach (var element in UserRolesID)
                    //{
                    //    var RoleName = UserRoles.Where(r => r.Id == element).FirstOrDefault();
                    //    if (RoleName != null)
                    //    {
                    //        UserRoleName.Add(RoleName.Name);
                    //    }
                    //    else
                    //    {
                    //        ViewBag.GetUserRolesResultMessage = "There are not exist roles for u  sername: " + UserName + ". Cannot exist a User without roles. Please check the database.";
                    //    }
                    //}

                    //var MyUserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    //ViewBag.RolesForThisUser = await MyUserManager.GetRolesAsync(User.Id);

                
                    
                        ViewBag.RolesForThisUser = await MyUserManager.GetRolesAsync(User.Id);
                   
                }
                else
                {
                    ViewBag.GetUserRolesResultMessage = ("There is not exist a user with Username: " + UserName);
                }              
               
            }

            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;
            return PartialView("_ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> DeleteRoleFromUser(string UserName, string RoleName)
        {
            CustomRoles.Roles MyCustomRoles = new CustomRoles.Roles();

            //Initialize CustomRoles Class in order to create the NoLessAccess property and to check for the nesseccery who cant be deleted.
             if (!CustomRoles.Roles.NoLessAccess.Contains(RoleName))
             {

                 var roleStore = new RoleStore<IdentityRole>(context);
                 var MyRoleManager = new RoleManager<IdentityRole>(roleStore);
                 var MyUserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                 var User = MyUserManager.Users.Where(u => u.UserName == UserName).FirstOrDefault();
                 //var User =  MyUserManager.Users.FirstOrDefault(u => u.UserName == UserName);

                // var User = context.Users.ToList().Where(x => x.UserName == UserName).FirstOrDefault();
                 if (User != null)
                 {
                     if (MyRoleManager.RoleExists(RoleName))
                     {
                         if (await MyUserManager.IsInRoleAsync(User.Id,RoleName))
                         {
                             try
                             {
                                     MyUserManager.RemoveFromRole(User.Id, RoleName);
                                     ViewBag.DeleteRoleFromUserResultMessage = "Role deleted successfully.";
                             }
                             catch (Exception)
                             {
                                 
                                 ViewBag.DeleteRoleFromUserResultMessage = "The system can not delete the role.";
                             }
                         }
                         else
                         {
                             ViewBag.DeleteRoleFromUserResultMessage = "The role is not deleted. The record does not exist.";
                         }
                     }
                     else
                     {
                         ViewBag.DeleteRoleFromUserResultMessage = "The role: " + RoleName + " does not exist.";
                     }
                 }
                 else
                 {
                     ViewBag.DeleteRoleFromUserResultMessage = ("There is not exist a user with Username: " + UserName);
                 }
             }
             else
             {
                 ViewBag.DeleteRoleFromUserResultMessage = "Can not delete the role: " + RoleName + " because it is a necessary role for all users.";
             }

             var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
             ViewBag.Roles = list;
             return PartialView("_ManageUserRoles");
        }
    }
}