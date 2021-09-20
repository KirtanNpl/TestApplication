using Bussiness.Services.Interface;
using Dto.DTO;
using Dto.Enum;
using Infrastructure.Entity;
using Infrastructure.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeService;
        private readonly IQualificationListRepository _qualificationService;
        private readonly IBaseRepository<Employee> _employeeRepo;
        public EmployeeController(IEmployeeRepository employeeService, IBaseRepository<Employee> employeeRepo, IQualificationListRepository qualificationService)
        {
            _employeeService = employeeService;
            _employeeRepo = employeeRepo;
            _qualificationService = qualificationService;
        }
        public IActionResult Index()
        {
            var data = _employeeRepo.getQueryable().ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult SaveEmployee()
        {

            var qualificationList = _qualificationService.AllQualificationDropDown();
            ViewBag.qualification = new SelectList(qualificationList, "Id", "DisplayName");

            ViewBag.GenderDropDown = from Gender g in Enum.GetValues(typeof(Gender))
                                     select new
                                     {
                                         Id = ((int)g).ToString(),
                                         DisplayName = g
                                     };
            return View();
        }

        [HttpPost]
        public IActionResult SaveEmployee(EmployeeDTO dto)
        {
            try
            {

                var qualificationList = _qualificationService.AllQualificationDropDown();
                ViewBag.qualification = new SelectList(qualificationList, "Id", "DisplayName");

                ViewBag.GenderDropDown = from Gender g in Enum.GetValues(typeof(Gender))
                                         select new
                                         {
                                             Id = ((int)g).ToString(),
                                             DisplayName = g
                                         };
                _employeeService.AddEmployee(dto);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        [HttpGet]
        public IActionResult UpdateEmployee(long id)
        {
            try
            {

                var qualificationList = _qualificationService.AllQualificationDropDown();
                ViewBag.qualification = new SelectList(qualificationList, "Id", "DisplayName");

                ViewBag.GenderDropDown = from Gender g in Enum.GetValues(typeof(Gender))
                                         select new
                                         {
                                             Id = ((int)g).ToString(),
                                             DisplayName = g
                                         };

                if (id > 0)
                {
                   var data= _employeeService.GetByEmployeeID(id);
                    return View(data);
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        public IActionResult UpdateEmployee(EmployeeDTO dto)
        {
            try
            {
                var qualificationList = _qualificationService.AllQualificationDropDown();
                ViewBag.qualification = new SelectList(qualificationList, "Id", "DisplayName");

                ViewBag.GenderDropDown = from Gender g in Enum.GetValues(typeof(Gender))
                                         select new
                                         {
                                             Id = ((int)g).ToString(),
                                             DisplayName = g
                                         };

                _employeeService.UpdateEmployee(dto);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult DeleteEmployee(long id)
        {
            try
            {
                if (id > 0)
                {
                    _employeeService.DeleteEmployee(id);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
