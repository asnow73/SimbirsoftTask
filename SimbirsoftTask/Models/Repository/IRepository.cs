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

        /*bool CreateRole(Role instance);

        bool UpdateRole(Role instance);

        bool RemoveRole(int idRole);*/

        #endregion
    }
}
