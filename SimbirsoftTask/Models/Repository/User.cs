using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Helpers;
using System.Security.Cryptography;

namespace SimbirsoftTask.Models.Repository
{
    public partial class SqlRepository : IRepository
    {
        public IQueryable<User> Users
        {
            get
            {
                var users = Db.Users.Include(p => p.Role);
                return users;
            }
        }

        public User GetUser(int? id)
        {
            User user = Db.Users.Find(id);
            return user;
        }

        public User GetUserByEmail(string email)
        {
            User user = (from u in Db.Users
                         where u.Email == email
                         select u).FirstOrDefault();
            return user;
        }

        public bool CreateUser(User instance)
        {
            if (instance.Id == 0)
            {
                instance.Password = Crypto.HashPassword(instance.Password);
                Db.Users.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        
        public bool UpdateUser(User instance)
        {
            User user = Db.Users.Where(p => p.Id == instance.Id).FirstOrDefault();
            if (user != null)
            {
                user.Email = instance.Email;
                user.Password = Crypto.HashPassword(instance.Password);
                user.Name = instance.Name;
                user.Surname = instance.Surname;
                user.Birthday = instance.Birthday;
                user.RoleId = instance.RoleId;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool RemoveUser(int id)
        {
            User instance = Db.Users.Where(p => p.Id == id).FirstOrDefault();
            if (instance != null)
            {
                db.Users.Remove(instance);
                db.SaveChanges();
                return true;
            }

            return false;
        }

    }
}