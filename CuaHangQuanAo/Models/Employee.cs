using System;
using System.Collections.Generic;

namespace CuaHangQuanAo.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
            Posts = new HashSet<Post>();
        }

        public int EmpId { get; set; }
        public string EmpName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Phone { get; set; }
        public int Gender { get; set; }
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime Birthday { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
