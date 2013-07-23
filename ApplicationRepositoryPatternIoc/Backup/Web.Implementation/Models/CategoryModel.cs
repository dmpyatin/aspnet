using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Implementation.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public List<ProductModel> Products { get; set; }

    }
}