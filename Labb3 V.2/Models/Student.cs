using System;
using System.Collections.Generic;

namespace Labb3_V._2.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades2tests = new HashSet<Grades2test>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public int? ClassId { get; set; }

        public virtual ICollection<Grades2test> Grades2tests { get; set; }
    }
}
