using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfRepPatTest.Entity
{
    public class Culture : BaseEntity
    {
        public virtual string Name { get; set; }

        public List<Translation> Translations { get; set; }
    }
}
