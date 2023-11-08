using System;
using System.Collections.Generic;

namespace CuaHangQuanAo.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CusId { get; set; }
        public string CusName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Phone { get; set; }
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string Status { get; set; } = null!;
        public int Gender { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
