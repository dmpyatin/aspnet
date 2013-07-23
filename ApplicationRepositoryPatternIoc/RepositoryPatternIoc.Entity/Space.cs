using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfRepPatTest.Entity
{
    public class Space : BaseEntity
    {
        public virtual string Name { get; set; }

        public virtual ICollection<Translation> Translations { get; set; }

        public Space()
        {
            Translations = new HashSet<Translation>();
        }
    }
}
