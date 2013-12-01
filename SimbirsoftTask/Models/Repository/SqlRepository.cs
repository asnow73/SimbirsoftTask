using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimbirsoftTask.Models.Repository
{
    public partial class SqlRepository : IRepository
    {
        private DataBaseContext db = new DataBaseContext();
        public DataBaseContext Db 
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