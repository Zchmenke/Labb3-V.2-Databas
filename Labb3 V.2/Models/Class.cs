using System;
using System.Collections.Generic;

namespace Labb3_V._2.Models
{
    public partial class Class
    {
        public int? ClassId { get; set; }
        public string Class1 { get; set; }

        public virtual Student ClassNavigation { get; set; }
    }
}
