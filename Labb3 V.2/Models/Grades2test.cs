using System;
using System.Collections.Generic;

namespace Labb3_V._2.Models
{
    public partial class Grades2test
    {
        public int StudentIdgrade { get; set; }
        public string GradeSub { get; set; }
        public int GradingTeacher { get; set; }
        public DateTime Gradedate { get; set; }
        public int Grade { get; set; }
        public int GradeId { get; set; }

        public virtual Personel GradingTeacherNavigation { get; set; }
        public virtual Student StudentIdgradeNavigation { get; set; }
    }
}
