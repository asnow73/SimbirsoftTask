using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimbirsoftTask.Models.Repository
{
    public partial class SqlRepository
    {
        public IQueryable<Role> Roles
        {
            get
            {
                return Db.Roles;
            }
        }

        public Role getRole(int? id)
        {
            Role role = Db.Roles.Find(id);
            return role;
        }


        /*public bool CreateUser(User instance)
        {
            if (instance.Id == 0)
            {
                Db.Users.InsertOnSubmit(instance);
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUser(User instance)
        {
            User cache = Db.Users.Where(p => p.Id == instance.Id).FirstOrDefault();
            if (cache != null)
            {
                cache.Email = instance.Email;
                cache.Password = instance.Password;
                cache.Name = instance.Name;
                cache.Surname = instance.Surname;
                cache.Birthday = instance.Birthday;
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveUser(int idUser)
        {
            User instance = Db.Users.Where(p => p.Id == idUser).FirstOrDefault();
            if (instance != null)
            {
                Db.Users.DeleteOnSubmit(instance);
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }*/

    }
}