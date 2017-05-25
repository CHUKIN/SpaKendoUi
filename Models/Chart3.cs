using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Лаба2.Models
{
    public class Chart3
    {


        public string state { get; set; }
        public double year { get; set; }
        public double amount { get; set; }
        public double cost { get; set; }

        public Chart3(string state, double year, double amount, double cost)
        {
            this.state = state;
            this.year = year;
            this.amount = amount;
            this.cost = cost;
        }
    }
}