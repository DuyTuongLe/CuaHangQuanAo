using System;
using System.Collections.Generic;

namespace CuaHangQuanAo.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Price { get; set; }
        public string Total { get; set; } = null!;
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
