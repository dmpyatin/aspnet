using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EfRepPatTest.Entity
{
    public interface IDatabase
    {
        void Add<TEntity>(TEntity entity) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;

        IQueryable<Product> GetProductsWithBound(int parameter);

        int UpdateProductNameById(string name, int id);

        IEnumerable<dynamic> GetSin(double argument);

        IEnumerable<dynamic> CountProductsByName(string name);

        IEnumerable<dynamic> CountProducts();

        IEnumerable<dynamic> SelectProductsIdAndName();

        IQueryable<Product> GetProducts { get; }

        IQueryable<Translation> GetTranslationsByNames(int cultureId, string[] elementNames);

    }
}
