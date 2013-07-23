using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfRepPatTest.Entity
{
    public interface ICurrentDatabase : IDatabase
    {
        IQueryable<Product> Products { get; }

        IQueryable<Category> Categories { get; }

        IQueryable<Culture> Cultures { get; }

        IQueryable<Translation> Translations { get; }
    }
}
