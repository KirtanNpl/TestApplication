using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.DTO
{
    public class EmployeeDTO
    {
        public long Employee_Id { get; set; }
        public string Emp_Name { get; set; }
        public DateTime DOB { get; set; }
        public int Gender { get; set; }
        public long Salary { get; set; }
        public string Entry_By { get; set; }
        public DateTime Entry_Date { get; set; }

        public virtual List<EmployeeQualificationDTO> EmployeeQualifications { get; set; } = new List<EmployeeQualificationDTO>();

        public class EmployeeQualificationDTO
        {
            public long empl_id { get; set; }
            public long Qualification_id { get; set; }
            public decimal Marks { get; set; }




        }
    }
}
