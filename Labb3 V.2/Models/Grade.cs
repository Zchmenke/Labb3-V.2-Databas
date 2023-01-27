using System;
using System.Collections.Generic;

namespace Labb3_V._2.Models
{
    public partial class Grade
    {
        public int GradesId { get; set; }
        public string Maths { get; set; }
        public string English { get; set; }
        public string History { get; set; }
        public int GradingTeacher { get; set; }
        public DateTime GradeDate { get; set; }

        public virtual Student Grades { get; set; }
        public virtual Personel GradingTeacherNavigation { get; set; }
    }
}
