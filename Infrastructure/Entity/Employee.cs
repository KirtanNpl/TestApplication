using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
   public class Employee
    {
        [Key]
        public long Employee_Id { get; set; }

        [RegularExpression(@"/^[a-zA-Z]+$/")]
        [Required]
        public string Emp_Name { get; set; }

        [RegularExpression(@"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$")]
        public DateTime DOB { get; set; }
        [Required]
        public int Gender{ get; set; }
        public long Salary { get; set; }
        public string Entry_By { get; set; }
        public DateTime Entry_Date { get; set; }

        public virtual List<EmployeeQualification> EmployeeQualifications { get; set; } = new List<EmployeeQualification>();

        public class EmployeeQualification
        {
            [Key]
            public long Empl_id { get; set; }
            [Required]
            public long Qualification_id { get; set; }
            public decimal Marks { get; set; }

            [ForeignKey(nameof(Empl_id))]
            public virtual Employee Employee { get; set; }

            [ForeignKey(nameof(Qualification_id))]
            public virtual QualificationList QualificationList { get; set; }


        }
    }
}
