using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfRepPatTest.Entity
{
    public class BaseService
    {
        public Lazy<ICurrentDatabase> Database { get; set; }

        static protected void Crud<T>(Action<T> crudParam, T entity) where T : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                if(crudParam != null){
                    crudParam(entity);
                }
            }
        }

        public void Add(BaseEntity entity)
        {
            Crud(Database.Value.Add, entity);
        }

        public void Update(BaseEntity entity)
        {
            Crud(Database.Value.Update, entity);
        }

        public void Delete(BaseEntity entity)
        {
            Crud(Database.Value.Delete, entity);
        }
    }
}
