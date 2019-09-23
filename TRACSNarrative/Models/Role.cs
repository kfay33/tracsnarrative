using System;
using System.Collections.Generic;

namespace TRACSNarrative.Models
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
