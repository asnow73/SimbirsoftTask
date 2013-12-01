using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SimbirsoftTask.Models.Repository
{
    public partial class SqlRepository : IRepository
    {
        public IQueryable<Role> Roles
        {
            get
            {
                return Db.Roles;
            }
        }

        public Role GetRole(int? id)
        {
            Role role = Db.Roles.Find(id);
            return role;
        }


        public bool CreateRole(Role instance)
        {
            if (instance.Id == 0)
            {
                Db.Roles.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }
        
        public bool UpdateRole(Role instance)
        {
            Role role = Db.Roles.Where(p => p.Id == instance.Id).FirstOrDefault();
            if (role != null)
            {                
                role.Name = instance.Name;
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }

            return false;
        }
        
        public bool RemoveRole(int id)
        {
            Role instance = Db.Roles.Where(p => p.Id == id).FirstOrDefault();
            if (instance != null)
            {
                db.Roles.Remove(instance);
                db.SaveChanges();
                return true;
            }

            return false;
        }

    }
}