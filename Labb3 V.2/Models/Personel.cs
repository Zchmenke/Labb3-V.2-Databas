using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labb3_V._2.Models
{
    public partial class Personel
    {
        public Personel()
        {
            Grades = new HashSet<Grade>();
        }
        
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int EmployeeRole { get; set; }

        public virtual RoleList EmployeeRoleNavigation { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
