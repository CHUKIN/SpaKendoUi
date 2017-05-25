using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Лаба2.Models
{
    

    public class Chart2
    {
        public string mark { get; set; }
        public int cost { get; set; }

        public Chart2(int cost, string mark)
        {
            this.mark = mark;
            this.cost = cost;
        }
    }
}