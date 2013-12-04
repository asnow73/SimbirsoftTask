using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Helpers;
using System.Security.Cryptography;
using System.Web.WebPages;
using Microsoft.Internal.Web.Utils;
using SimbirsoftTask.Models;
using SimbirsoftTask.Models.Repository;

namespace SimbirsoftTask.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string email)
        {
            string[] role = new string[] { };
            
            try
            {
                using (SqlRepository repo = new SqlRepository())
                {
                    User user = repo.GetUserByEmail(email);
                    if (user != null)
                    {                       
                        //Role userRole = _db.Roles.Find(user.RoleId);
                        Role userRole = user.Role;

                        if (userRole != null)
                        {
                            role = new string[] { userRole.Name };
                        }
                    }
                }
            }
            catch
            {
                role = new string[] { };
            }
            return role;
        }

        public override void CreateRole(string roleName)
        {
            using (SqlRepository repo = new SqlRepository())
            {
                Role role = new Role();
                role.Name = roleName;
                repo.CreateRole(role);
            }
        }

        public override bool IsUserInRole(string email, string roleName)
        {
            bool outputResult = false;
            try
            {
                using (SqlRepository repo = new SqlRepository())
                {
                    User user = repo.GetUserByEmail(email);
                    if (user != null)
                    {
                        // получаем роль
                        //Role userRole = _db.Roles.Find(user.RoleId);
                        Role userRole = user.Role;

                        //сравниваем
                        if (userRole != null && userRole.Name == roleName)
                        {
                            outputResult = true;
                        }
                    }
                }
            }
            catch
            {
                outputResult = false;
            }
            return outputResult;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}