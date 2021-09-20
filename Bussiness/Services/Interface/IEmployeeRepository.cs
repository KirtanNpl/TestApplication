using Dto.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Interface
{
   public  interface IEmployeeRepository
    {
        void AddEmployee(EmployeeDTO dto);

        void UpdateEmployee(EmployeeDTO dto);

        void DeleteEmployee(long id);

        EmployeeDTO GetByEmployeeID(long id);
    }
}
