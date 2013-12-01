using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirsoftTask.Models.Repository
{
    interface IRepository
    {
        #region Role
        IQueryable<Role> Roles { get; }

        Role GetRole(int? id);

        bool CreateRole(Role instance);

        bool UpdateRole(Role instance);

        bool RemoveRole(int id);

        #endregion

        #region User
        IQueryable<User> Users { get; }

        User GetUser(int? id);

        bool CreateUser(User instance);

        /*bool UpdateUser(User instance);

        bool RemoveUser(int id);*/

        #endregion
    }
}
