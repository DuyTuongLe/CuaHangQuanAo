using System;
using System.Collections.Generic;

namespace CuaHangQuanAo.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShoppingAddress { get; set; } = null!;
        public int TotalPrice { get; set; }
        public string PaymentMenthod { get; set; } = null!;
        public string Note { get; set; } = null!;
        public string Discount { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int EmpId { get; set; }
        public int CusId { get; set; }
        public int? PaymentId { get; set; }

        public virtual Customer Cus { get; set; } = null!;
        public virtual Employee Emp { get; set; } = null!;
        public virtual Payment? Payment { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
