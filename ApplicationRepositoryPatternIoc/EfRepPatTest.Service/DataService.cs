using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using System.Linq;

using EfRepPatTest.Data;
using EfRepPatTest.Entity;
using System.Data.SqlClient;
using System.Data;

namespace EfRepPatTest.Service
{
    public class DataService : BaseService, IDataService
    {

        public DataService()
        {

        }

        public DataService(Lazy<ICurrentDatabase> database)
        {
            Database = database;
        }

        
        public IQueryable<Category> GetCategories
        {
            get
            {
                return Database.Value.Categories;
            }
        }

        public Category GetCategoryById(int id)
        {

            return Database.Value.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public Product GetProductById(int id)
        {
            return Database.Value.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public IQueryable<Category> GetAllCategories
        {
            //var test = Database.Categories.Include(x => x.Products).ToList();
            get
            {
                return Database.Value.Categories.Include(x => x.Products);
            }
        }

        public IQueryable<Product> GetAllProducts
        {
            //var test = Database.Products.Include(x => x.Category).ToList();
            get
            {
                return Database.Value.Products.Include(x => x.Category);
            }
        }


        public IQueryable<Culture> GetAllCultures
        {
            get
            {
                return Database.Value.Cultures;
            }
        }

        public Translation GetTranslation(string Name, int? CultureId)
        {

            return Database.Value.Translations.Where(p => p.Name == Name && p.CultureId == CultureId).FirstOrDefault();
        }


        public IQueryable<Translation> GetTranslations(int? cultureId, string spaceName)
        {
           //return Database.GetTranslationsByNames(cultureId, elementNames);
           // var t = Database.Translations.Where(x => x.Spaces.Any(s => s.Name == spaceName)).ToList();
            return Database.Value.Translations.Where(x => x.CultureId == cultureId && x.Spaces.Any(s => s.Name == spaceName));
        }

    }
}
