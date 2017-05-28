using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Лаба2.Models
{
    public class LabaContext : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; }
    }
}