using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4.Domain.Entity
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
    }
}
