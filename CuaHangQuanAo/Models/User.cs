using System;
using System.Collections.Generic;

namespace CuaHangQuanAo.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Gender { get; set; }
        public int Phone { get; set; }
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
    }
}
