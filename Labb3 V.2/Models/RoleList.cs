using System;
using System.Collections.Generic;

namespace Labb3_V._2.Models
{
    public partial class RoleList
    {
        public RoleList()
        {
            Personels = new HashSet<Personel>();
        }

        public int RoleId { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Personel> Personels { get; set; }
    }
}
