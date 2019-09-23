using System;
using System.Collections.Generic;

namespace TRACSNarrative.Models
{
    public partial class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
