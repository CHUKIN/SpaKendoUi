using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Лаба2.Models
{
    public class Chart1
    {
        public string name { get; set; }
        public int value { get; set; }

        public List<Chart1> items { get; set; }

        public Chart1()
        {
            items = new List<Chart1>();
        }

        public Chart1(string name, int value)
        {
            items = new List<Chart1>();
            this.name = name;
            this.value = value;
        }

    }
}