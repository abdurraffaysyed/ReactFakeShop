using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeShopBackend.Models
{
    public class Rating
    {
        public float rate { get; set; }
        public int count { get; set; }
        public int product_id { get; set; }
    }
}
