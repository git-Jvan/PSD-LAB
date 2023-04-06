using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;

namespace KpopZtation.Repositories
{
    public class Database
    {
        private static Database1Entities1 db = null;

        public static Database1Entities1 getDB()
        {
            if(db == null)
            {
                db = new Database1Entities1();
            }
            return db;
        }
    }
}