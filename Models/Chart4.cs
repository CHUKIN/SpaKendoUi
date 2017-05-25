using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Лаба2.Models
{
    public class Chart4
    {
        //цена от Года выпуска

        public string type { get; set; }
        public string year { get; set; }
        public int cost { get; set; }


        public Chart4(string type, string year,  int cost  )
        {
            this.type = type;
            this.year = year;
            this.cost = cost;
        }
    }
}