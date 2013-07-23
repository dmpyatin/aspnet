using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfRepPatTest.Entity;
using EfRepPatTest.Data.Mapping;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;

namespace EfRepPatTest.Data
{
    public sealed class CurrentContext : BaseContext, ICurrentDatabase
    {
        #region Tables

        public IQueryable<Category> Categories { get; set; }

        public IQueryable<Product> Products { get; set; }

        public IQueryable<Culture> Cultures { get; set; }

        public IQueryable<Translation> Translations { get; set; }

        public IQueryable<Space> Spaces { get; set; }

        #endregion

        public CurrentContext()
        {
            /*Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;*/
          
            Initialize();
        }

        protected override void Initialize()
        {
            Categories = Set<Category>();
            Products = Set<Product>();
            Cultures = Set<Culture>();
            Translations = Set<Translation>();
            Spaces = Set<Space>();
        
            base.Initialize();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                modelBuilder.Configurations.Add(new ProductMap());
                modelBuilder.Configurations.Add(new CategoryMap());
                modelBuilder.Configurations.Add(new CultureMap());
                modelBuilder.Configurations.Add(new TranslationMap());
                modelBuilder.Configurations.Add(new SpaceMap());

                base.OnModelCreating(modelBuilder);
            }
        }

        
        protected override void Dispose(bool disposing)
        {
            Configuration.LazyLoadingEnabled = false;
            base.Dispose(disposing);
        }

        public IQueryable<Product> GetProductsWithBound(int parameter)
        {
            return RawSqlQuery<Product>("EXEC GetProductsWithBound {0}", parameter);
        }


        public int UpdateProductNameById(string name, int id)
        {
            return RawSqlCommand(@"UPDATE dbo.Product SET dbo.Product.Name = {0} FROM dbo.Product WHERE dbo.Product.Id = {1}", name, id);
        }

        public IEnumerable<dynamic> GetSin(double argument)
        {
            var arg = new SqlParameter("Arg", argument);
            return RawSqlQuery(
                new List<Type>() { typeof(double) },
                new List<string>() { "sin" },
                 @"select Sin(@Arg) as sin",
                 new object[]{
                    arg
                 });
        }

        public IEnumerable<dynamic> CountProductsByName(string name)
        {
            return RawSqlQuery(
                new List<Type>(){typeof(int)}, 
                new List<string>(){"count"},
                 @"select count(*) as count from dbo.Product where Name = {0}", name);
        }

        public IEnumerable<dynamic> CountProducts()
        {
            return RawSqlQuery(
                new List<Type>() { typeof(int) },
                new List<string>() { "count" },
                "select count(*) as count from dbo.Product");
        }

        public IEnumerable<dynamic> SelectProductsIdAndName()
        {
            return RawSqlQuery(
                new List<Type>() { typeof(int), typeof(string) },
                new List<string>() { "Id", "Name" },
                "select Id, Name from dbo.Product");
        }

        public IQueryable<Product> GetProducts
        {
            get
            {
                return RawSqlQuery<Product>("SELECT * FROM dbo.Product");
            }
        }

        public IQueryable<Translation> GetTranslationsByNames(int cultureId, string[] elementNames)
        {
            var query = "SELECT * FROM dbo.Translation WHERE CultureId = " + cultureId.ToString() + " AND (";
            for (int i = 0; i < elementNames.Length; ++i)
            {
                if (i != elementNames.Length - 1)
                    query += "Name = '" + elementNames[i] + "' OR ";
                else
                    query += "Name = '" + elementNames[i] + "')";
            }

            return RawSqlQuery<Translation>(query);
        }
    }
}
