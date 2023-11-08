using System;
using System.Collections.Generic;

namespace CuaHangQuanAo.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string NameProduct { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public int QuantityInventory { get; set; }
        public int CatogoryId { get; set; }
        public int? SupId { get; set; }

        public virtual Category Catogory { get; set; } = null!;
        public virtual Supplier? Sup { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
