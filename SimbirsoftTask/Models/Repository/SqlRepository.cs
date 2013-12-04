using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimbirsoftTask.Models.Repository
{
    public partial class SqlRepository : IRepository, IDisposable
    {
        private DataBaseContext db = new DataBaseContext();
        private DataBaseContext Db 
        {
            get
            {
                return db;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}