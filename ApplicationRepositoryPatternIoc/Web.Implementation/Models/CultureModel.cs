using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EfRepPatTest.Entity;
using EfRepPatTest.Service;

namespace Web.Implementation.Models
{
    public class CultureModel
    {
        public int cultureId { get; set; }

        public IEnumerable<Culture> Cultures { get; set; }
    }
}