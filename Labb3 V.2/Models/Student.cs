using System;
using System.Collections.Generic;

namespace Labb3_V._2.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public int? ClassId { get; set; }

        public virtual Grade Grade { get; set; }
    }
}
