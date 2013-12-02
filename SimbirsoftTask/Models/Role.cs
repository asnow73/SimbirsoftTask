using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimbirsoftTask.Models
{
    public class Role
    {
        // ID роли
        public virtual int Id { get; set; }
        // Название роли
        public virtual string Name { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}