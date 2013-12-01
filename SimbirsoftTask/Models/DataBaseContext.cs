using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SimbirsoftTask.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
    }
}