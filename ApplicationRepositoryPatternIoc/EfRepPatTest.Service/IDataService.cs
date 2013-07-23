using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfRepPatTest.Entity;

namespace EfRepPatTest.Service
{
    public interface IDataService
    {
        IQueryable<Category> GetCategories { get; }

        void Add(BaseEntity entity);

        void Update(BaseEntity entity);

        void Delete(BaseEntity entity);

        IQueryable<Category> GetAllCategories { get; }

        IQueryable<Product> GetAllProducts { get; }

        Category GetCategoryById(int id);

        Product GetProductById(int id);

        IQueryable<Culture> GetAllCultures { get; }

        Translation GetTranslation(string Name, int? CultureId);

        IQueryable<Translation> GetTranslations(int? cultureId, string spaceName);
    }
}
