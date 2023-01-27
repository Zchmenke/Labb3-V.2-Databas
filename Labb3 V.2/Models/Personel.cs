using System;
using System.Collections.Generic;

namespace Labb3_V._2.Models
{
    public partial class Personel
    {
        public Personel()
        {
            Grades2tests = new HashSet<Grades2test>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int EmployeeRole { get; set; }

        public virtual RoleList EmployeeRoleNavigation { get; set; }
        public virtual ICollection<Grades2test> Grades2tests { get; set; }
    }
}
