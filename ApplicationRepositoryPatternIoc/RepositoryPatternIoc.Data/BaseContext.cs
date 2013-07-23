using System;
using System.Data.Entity;
using System.Linq;
using EfRepPatTest.Entity;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data;
using System.Reflection.Emit;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data.SqlClient;
using System.Data.Objects;

namespace EfRepPatTest.Data
{
    public class BaseContext : DbContext
    {
        protected virtual void Initialize()
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;
            Configuration.AutoDetectChangesEnabled = false;
            //Configuration.ValidateOnSaveEnabled = true;
        }

        public virtual void Add<TEntity>(TEntity entity) where TEntity : class
        {
            AttachIfNotAttached(entity);
            Set(entity.GetType()).Add(entity);
            SaveChanges();
        }

        public virtual void Update<TEntity>(TEntity entity) where TEntity : class
        {
            AttachIfNotAttached(entity);
            Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        public virtual void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            AttachIfNotAttached(entity);
            Set(entity.GetType()).Remove(entity);
            Entry(entity).State = EntityState.Deleted;
            SaveChanges();
        }

        private void AttachIfNotAttached<TEntity>(TEntity entity) where TEntity : class
        {
            if (Entry(entity).State != EntityState.Detached)
                return;
            Set(entity.GetType()).Attach(entity);
        }

        protected IQueryable<TEntity> RawSqlQuery<TEntity>(string query, params object[] parameters) where TEntity : class
        {
            var result = Set<TEntity>().SqlQuery(query, parameters).AsQueryable();

            return result;
        }

        protected int RawSqlCommand(string command, params object[] parameters)
        {         
            return Database.ExecuteSqlCommand(command, parameters);
        }

        protected IEnumerable<dynamic> RawSqlQuery(List<Type> types, List<string> names, string query, params object[] parameters)
        {
            TypeBuilder builder = BaseContext.CreateTypeBuilder("MyDynamicAssembly", "MyModule", "MyType");

            var typesAndNames = types.Zip(names, (t, n) => new { Type = t, Name = n });
            foreach (var tn in typesAndNames)
            {
                BaseContext.CreateAutoImplementedProperty(builder, tn.Name, tn.Type);
            }
       
            Type resultType = builder.CreateType();

            return Database.SqlQuery(resultType, query, parameters).Cast<dynamic>();
        }


        static TypeBuilder CreateTypeBuilder(
           string assemblyName, string moduleName, string typeName)
        {
            TypeBuilder typeBuilder = AppDomain
                .CurrentDomain
                .DefineDynamicAssembly(new AssemblyName(assemblyName),
                                       AssemblyBuilderAccess.Run)
                .DefineDynamicModule(moduleName)
                .DefineType(typeName, TypeAttributes.Public);
            typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
            return typeBuilder;
        }

       static void CreateAutoImplementedProperty(
            TypeBuilder builder, string propertyName, Type propertyType)
        {
            const string PrivateFieldPrefix = "m_";
            const string GetterPrefix = "get_";
            const string SetterPrefix = "set_";

            // Generate the field.
            FieldBuilder fieldBuilder = builder.DefineField(
                string.Concat(PrivateFieldPrefix, propertyName),
                              propertyType, FieldAttributes.Private);

            // Generate the property
            PropertyBuilder propertyBuilder = builder.DefineProperty(
                propertyName, System.Reflection.PropertyAttributes.HasDefault, propertyType, null);

            // Property getter and setter attributes.
            MethodAttributes propertyMethodAttributes =
                MethodAttributes.Public | MethodAttributes.SpecialName |
                MethodAttributes.HideBySig;

            // Define the getter method.
            MethodBuilder getterMethod = builder.DefineMethod(
                string.Concat(GetterPrefix, propertyName),
                propertyMethodAttributes, propertyType, Type.EmptyTypes);

            // Emit the IL code.
            // ldarg.0
            // ldfld,_field
            // ret
            ILGenerator getterILCode = getterMethod.GetILGenerator();
            getterILCode.Emit(OpCodes.Ldarg_0);
            getterILCode.Emit(OpCodes.Ldfld, fieldBuilder);
            getterILCode.Emit(OpCodes.Ret);

            // Define the setter method.
            MethodBuilder setterMethod = builder.DefineMethod(
                string.Concat(SetterPrefix, propertyName),
                propertyMethodAttributes, null, new Type[] { propertyType });

            // Emit the IL code.
            // ldarg.0
            // ldarg.1
            // stfld,_field
            // ret
            ILGenerator setterILCode = setterMethod.GetILGenerator();
            setterILCode.Emit(OpCodes.Ldarg_0);
            setterILCode.Emit(OpCodes.Ldarg_1);
            setterILCode.Emit(OpCodes.Stfld, fieldBuilder);
            setterILCode.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getterMethod);
            propertyBuilder.SetSetMethod(setterMethod);
        }
    }
}
