using System;
using System.Collections.Generic;

namespace CuaHangQuanAo.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime ModifiedAt { get; set; }
        public int EmpId { get; set; }

        public virtual Employee Emp { get; set; } = null!;
    }
}
