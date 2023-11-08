using System;
using System.Collections.Generic;

namespace CuaHangQuanAo.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int SupId { get; set; }
        public string SupName { get; set; } = null!;
        public string Address { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
