using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Implementation.Models
{
     [Serializable]
    public class TranslationPageQueryModel
    {
       
        public int cultureId { get; set; }
        public string spaceName { get; set; }
        //public string[] elementNames { get; set; }
    }

}