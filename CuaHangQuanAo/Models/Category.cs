using System;
using System.Collections.Generic;

namespace CuaHangQuanAo.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CatogoryId { get; set; }
        public string NameCate { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
