using System;
using System.Collections.Generic;

namespace TRACSNarrative.Models
{
    public partial class UserRoles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
