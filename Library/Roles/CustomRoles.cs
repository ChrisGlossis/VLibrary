using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.CustomRoles
{
    public sealed class Roles
    {
        // List of necessary roles to db
        static private List<string> ObligatoryRoles = new List<string> { "Admin", "Modarator", "User" };

        //Role holder
        static private List<string> _RoleList = ObligatoryRoles;
        //Necessary access level for all users holder
        static private List<string> _NoLessAccess;
        
        static public List<string> NoLessAccess
        {
            get { return _NoLessAccess; }
            private set { _NoLessAccess = NoLessAccess; } 
        }

       
      
        static  public List<string> RolesList 
        {
            get { return _RoleList; }
            private set { _RoleList = RoleList; } 
        }

        //Adding roles to Role List if not exist
        public void AddRole(string Role)
        {
            if (!_RoleList.Contains(Role))
            {
                _RoleList.Add(Role);
              
            }         
        }

        //Set minimum Role requirement
       public void SetMinimumAccess(string Role)
        {
            if (!_NoLessAccess.Contains(Role))
            {
                _NoLessAccess.Add(Role);
              
            }         
        }

       //Default Constructor. If MinimumAccess is not set then auto-set to user
        public Roles()
        {
            if (_NoLessAccess==null)
            {
                _NoLessAccess = new List<string>();
                _NoLessAccess.Add("User");
            }
        }

        //Constructor. Add Roles and Set MinimumAccess
        public Roles(List<string> RoleList, List<string> MinimumAccess)
        {
            _NoLessAccess = new List<string>();

            if (RoleList!=null)
            {
                foreach (string element in RoleList)
                {
                    AddRole(element);
                }
            }
            if (MinimumAccess != null)
            {
                foreach (string element in MinimumAccess)
                {
                    SetMinimumAccess(element);
                }
            } 
            else
            {
                _NoLessAccess.Add("User");
            }
        }


        public static List<string> RoleList { get; set; }
    }

       
}