using Bussiness.Services.Interface;
using Dto.DTO;
using Infrastructure.Entity;
using Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dto.DTO.EmployeeDTO;
using static Infrastructure.Entity.Employee;

namespace Bussiness.Services.Implementation
{
    public class EmployeeService: IEmployeeRepository
    {
        private readonly IBaseRepository<Employee> _employeeRepo;
        private readonly IBaseRepository<EmployeeQualification> _employeeQualRepo;
        public EmployeeService(IBaseRepository<Employee> employeeRepo,IBaseRepository<EmployeeQualification> employeeQualRepo)
        {
            _employeeRepo = employeeRepo;
            _employeeQualRepo = employeeQualRepo;
        }


        private void saveEmployeeQualification(EmployeeDTO dto, long id)
        {
            List<EmployeeQualification> EmployeeQual = new List<EmployeeQualification>();
            foreach (var item in dto.EmployeeQualifications)
            {
                if (item.Marks <= 100)
                {
                    EmployeeQualification employeeQualification = new EmployeeQualification();
                    employeeQualification.Empl_id = id;
                    employeeQualification.Marks = item.Marks;
                    employeeQualification.Qualification_id = item.Qualification_id;

                    EmployeeQual.Add(employeeQualification);
                }
            }
            _employeeQualRepo.InsertRange(EmployeeQual);
        }

        private void deleteEmpoyeeQualfiacation(long id)
        {
            var lists = _employeeQualRepo.getQueryable().Where(a => a.Empl_id == id).ToList();
            _employeeQualRepo.DeleteRange(lists);
        }

        public void AddEmployee(EmployeeDTO dto)
        {
            var mapData = MapFromDTOtoEntity(new Employee(), dto);
            _employeeRepo.Insert(mapData);
          saveEmployeeQualification(dto, mapData.Employee_Id);

        }

        public void UpdateEmployee(EmployeeDTO dto)
        {
            var data = _employeeRepo.getById(dto.Employee_Id);
            var mapData = MapFromDTOtoEntity(data, dto);
            _employeeRepo.Update(mapData);
            deleteEmpoyeeQualfiacation(mapData.Employee_Id);
            saveEmployeeQualification(dto, mapData.Employee_Id);


        }

        public void DeleteEmployee(long id)
        {
            if (id > 0)
            {
                var dataToDelete = _employeeRepo.getById(id);
                _employeeRepo.Delete(dataToDelete);
                deleteEmpoyeeQualfiacation(id);

            }

        }

        public EmployeeDTO GetByEmployeeID(long id)
        {
            var data = _employeeRepo.getById(id);
            var mappeddata = MapFromEnitytoDTO(data, new EmployeeDTO());
            return mappeddata;
        }
        public Employee MapFromDTOtoEntity(Employee entity,EmployeeDTO dto)
        {
            entity.Employee_Id = dto.Employee_Id;
            entity.Emp_Name = dto.Emp_Name;
            entity.DOB = dto.DOB;
            entity.Entry_By = dto.Entry_By;
            entity.Entry_Date = dto.Entry_Date;
            entity.Gender = dto.Gender;
            entity.Salary = dto.Salary;

            return entity;

        }

        public EmployeeDTO MapFromEnitytoDTO(Employee entity, EmployeeDTO dto)
        {
            dto.Employee_Id = entity.Employee_Id;
            dto.Emp_Name = entity.Emp_Name;
            dto.DOB = entity.DOB;
            dto.Entry_By = entity.Entry_By;
            dto.Entry_Date = entity.Entry_Date;
            dto.Gender = entity.Gender;
            dto.Salary = entity.Salary;

            foreach (var item in entity.EmployeeQualifications)
            {
                dto.EmployeeQualifications.Add(new EmployeeQualificationDTO()
                {
                    Qualification_id = item.Qualification_id,
                    Marks = item.Marks
                });
            }



            return dto;

        }
    }
}
