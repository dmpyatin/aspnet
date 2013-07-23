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
    public class Translation : BaseEntity
    {
        public virtual string Name { get; set; }

        public virtual int CultureId { get; set; }

        public virtual Culture Culture { get; set; }

        public virtual string Text { get; set; }

        public virtual ICollection<Space> Spaces { get; set; }

        public Translation()
        {
            Spaces = new HashSet<Space>();
        }

    }
}