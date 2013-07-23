using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EfRepPatTest.Data.DbInitializer
{
    public class DatabaseInitializer : IDatabaseInitializer<CurrentContext>
    {
        public void InitializeDatabase(CurrentContext context)
        {
            if (context != null)
            {
                context.Database.CreateIfNotExists();
            }
        }
    }
}
